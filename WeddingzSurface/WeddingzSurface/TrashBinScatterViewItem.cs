using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Surface.Presentation.Controls;

namespace WeddingzSurface
{
    class TrashBinScatterViewItem : ScatterViewItem
    {

        public TrashBin trashBin;

        public TrashBinScatterViewItem(TrashBin trash)
        {
            this.Width = 130;
            this.Height = 130;
            this.MaxWidth = this.Width;
            this.MaxHeight = this.Height;
            this.MinWidth = this.Width;
            this.MinHeight = this.Height;
            Console.WriteLine("New Trash");
            this.trashBin = trash;
            this.initUI();
        }

        private void initUI()
        {
            this.Content = this.trashBin;
        }
    }
}
