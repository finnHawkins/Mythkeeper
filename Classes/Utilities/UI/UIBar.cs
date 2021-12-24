using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIBar : UIObject {

    private int width { get; set; }
    private int height { get; set; }
    private float maxVal { get; set; }
    private float currentVal { get; set; }

    public UIBar(String UItag, String val, int w, int h, int x, int y, float maxVal, float currentVal, Color fontColour) : base(UItag, val, x, y, fontColour) {

      this.maxVal = maxVal;
      this.currentVal = currentVal;
      width = w;
      height = h;

    }
    public override void Draw() {
     
    }

  }
}
