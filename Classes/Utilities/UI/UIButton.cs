using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public class UIButton : UIObject {

    private int width { get;set;}
    private int height { get;set;}

    public UIButton(String UItag, String val, int w, int h, int x, int y, Color fontColour) : base(UItag, val, x, y, fontColour) {

      width = w;
      height = h;

    }

    public override void Draw() {



    }

  }
}
