using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WeddingzSurface
{
    class TrashBin : LibraryStack
    {
        public TrashBin()
        {
            this.Width = 300;
            this.Height = 150;
            this.MaxWidth = this.Width;
            this.MaxHeight = this.Height;
            //SurfaceDragDrop.AddPreviewQueryTargetHandler(this, OnPreviewQueryTarget);
            SurfaceDragDrop.AddPreviewDropHandler(this, OnDrop);
            //SurfaceDragDrop.AddPreviewDropHandler(this, copyBack);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Jeremy\Documents\git\WeddingzSurface\WeddingzSurface\WeddingzSurface\Resources\trash_bin.png", UriKind.Absolute));
            this.Background = myBrush;
        }

        /// <summary>
        /// Called when something is tropped on this, manage the drop action
        /// </summary>
        public void OnDrop(Object sender, SurfaceDragDropEventArgs arg)
        {
            ProviderTemplate droppedCard = arg.Cursor.Data as ProviderTemplate;
            TrashBin sourceBar = arg.Cursor.DragSource as TrashBin;

            // Not handled
            if (droppedCard == null)
            {
                return;
            }

            droppedCard.setState(ProviderItemState.overview);

            if (sourceBar != null && sender != sourceBar)
            {
                /*if (sourceBar.containsCard(droppedCard) == null)
                {
                    sourceBar.Items.Add((ProviderTemplate)droppedCard);
                }
                 */
            }

            /*
            // Remove duplicated card
            Card alreadyInsideCard = this.containsCard(droppedCard);
            if (alreadyInsideCard != null)
            {
                this.Items.Remove(alreadyInsideCard);
            }
             */
        }
    }
}
