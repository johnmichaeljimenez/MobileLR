using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineType : MonoBehaviour {

    public enum LineTypes
    {
        Normal, Accelerator, Bounce, Brake
    }

    public LineTypes lineType;

}
