using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;

namespace WeddingzSurface
{
    class TrashBin : LibraryStack
    {
        public TrashBin()
        {
            //SurfaceDragDrop.AddPreviewQueryTargetHandler(this, OnPreviewQueryTarget);
            SurfaceDragDrop.AddPreviewDropHandler(this, OnDrop);
            //SurfaceDragDrop.AddPreviewDropHandler(this, copyBack);
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
        }
    }
}
