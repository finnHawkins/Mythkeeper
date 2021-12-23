using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIBar : UIObject {

    private int width { get; set; }
    private int height { get; set; }

    public UIBar(int w, int h, int x, int y, String val) : base(val, x, y) {

      width = w;
      height = h;

    }

  }
}
