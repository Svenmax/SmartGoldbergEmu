using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartGoldbergEmu.Services
{
    public class ViewManager
    {
        private readonly ListView _listView;
        private readonly ImageList _bigTileImages;
        private readonly ImageList _capsuleTileImages;
        public string CurrentViewMode { get; private set; }

        public ViewManager(ListView listView, ImageList bigTileImages, ImageList capsuleTileImages)
        {
            _listView = listView;
            _bigTileImages = bigTileImages;
            _capsuleTileImages = capsuleTileImages;
            CurrentViewMode = Properties.Settings.Default.ListViewMode ?? "Tile";
        }

        public void SetBigTileView()
        {
            _listView.View = View.Tile;
            _listView.LargeImageList = _bigTileImages;
            _listView.TileSize = new Size(256, 122);
            CurrentViewMode = "Tile";
            Save();
        }

        public void SetCapsuleTileView()
        {
            _listView.View = View.Tile;
            _listView.LargeImageList = _capsuleTileImages;
            _listView.TileSize = new Size(120, 48);
            CurrentViewMode = "CapsuleTile";
            Save();
        }

        public void RestoreView()
        {
            if (CurrentViewMode == "CapsuleTile")
                SetCapsuleTileView();
            else
                SetBigTileView();
        }

        private void Save()
        {
            Properties.Settings.Default.ListViewMode = CurrentViewMode;
            Properties.Settings.Default.Save();
        }
    }
} 