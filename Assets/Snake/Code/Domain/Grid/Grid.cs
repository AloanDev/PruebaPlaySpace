using System;

namespace Snake.Domain {
	public readonly struct Grid {
		public readonly int Columns;
		public readonly int Rows;
		private const int MINLength = 10;

		public Grid(int columns, int rows) {
			if (columns < MINLength || rows < MINLength) {
				throw new Exception($"Columns and rows must be bigger than {MINLength}");
			}

			Columns = columns;
			Rows = rows;
		}
	}
}