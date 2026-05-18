"""Optional 3D surface renderers for the review page.

The GUI talks to this small adapter instead of directly depending on a
specific 3D backend.  The current implementation keeps the lightweight
pyqtgraph/OpenGL path; a future PyVista backend can implement the same
surface/update/export methods without rewriting the review page.
"""

from __future__ import annotations

from typing import Optional

import numpy as np


try:
    import pyqtgraph.opengl as gl
    _HAS_PYG_GL = True
except Exception:
    gl = None
    _HAS_PYG_GL = False


class PyQtGraphSurfaceRenderer:
    """Render a scalar field surface with pyqtgraph.opengl."""

    backend_name = "pyqtgraph.opengl"

    @classmethod
    def is_available(cls) -> bool:
        return _HAS_PYG_GL and gl is not None

    def __init__(self) -> None:
        if not self.is_available():
            raise RuntimeError("pyqtgraph.opengl/PyOpenGL is not available")
        self.widget = gl.GLViewWidget()
        self.widget.setMinimumHeight(300)
        self.widget.setCameraPosition(distance=80, elevation=28, azimuth=45)
        self._grid_item = gl.GLGridItem()
        self._grid_item.setSize(40, 40, 1)
        self._grid_item.setSpacing(5, 5, 1)
        self.widget.addItem(self._grid_item)
        self._surface_item = None
        self._last_distance = 80.0

    @property
    def has_surface(self) -> bool:
        return self._surface_item is not None

    def clear(self) -> None:
        if self._surface_item is not None:
            try:
                self.widget.removeItem(self._surface_item)
            except Exception:
                pass
        self._surface_item = None

    def reset_view(self) -> None:
        self.widget.setCameraPosition(distance=self._last_distance, elevation=28, azimuth=45)

    def set_surface(
        self,
        xs: np.ndarray,
        ys: np.ndarray,
        grid: np.ndarray,
        colors: np.ndarray,
    ) -> float:
        """Render ``grid`` as z height and return the camera span used."""

        self.clear()
        finite = grid[np.isfinite(grid)]
        if finite.size == 0:
            raise ValueError("surface grid has no finite values")

        x_render = np.asarray(xs, dtype=float) - float(np.mean(xs))
        y_render = np.asarray(ys, dtype=float) - float(np.mean(ys))
        z_grid = np.asarray(grid, dtype=float).T
        z_fill = float(np.mean(finite))
        z_render = np.nan_to_num(z_grid, nan=z_fill)

        self._surface_item = gl.GLSurfacePlotItem(
            x=x_render,
            y=y_render,
            z=z_render,
            colors=colors,
            shader="heightColor",
            computeNormals=False,
            smooth=False,
            showGrid=True,
            glOptions="translucent",
        )
        self.widget.addItem(self._surface_item)
        span = max(
            float(np.ptp(x_render)) if len(x_render) > 1 else 1.0,
            float(np.ptp(y_render)) if len(y_render) > 1 else 1.0,
            float(np.ptp(finite)) if finite.size > 1 else 1.0,
            10.0,
        )
        self._last_distance = span * 2.4
        self.reset_view()
        return span

    def export_png(self, path: str) -> None:
        pixmap = self.widget.grab()
        if not pixmap.save(path, "PNG"):
            raise OSError("QPixmap.save returned false")


SurfaceRenderer = PyQtGraphSurfaceRenderer

