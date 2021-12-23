using sun.net.www.content.text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public abstract class UIObject {

    public string UIval { get; set; }
    private float x { get; set; }
    private float y { get; set; }
    private float scale { get; set; }

    public UIObject(string val, float x, float y, float scale = 1f) {

      UIval = val;
      this.x = x;
      this.y = y;
      this.scale = scale;

    }

  }
}
