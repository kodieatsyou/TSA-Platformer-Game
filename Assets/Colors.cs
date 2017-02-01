using UnityEngine;
using System.Collections;

public class Colors : MonoBehaviour {

    public Color red = new Color(1, 0, 0, 1);
    public Color blue = new Color(0, 0, 1, 1);
    public Color green = new Color(0, 1, 0, 1);
    public Color white = new Color(1, 1, 1, 1);
    public Color black = new Color(0, 0, 0, 1);
    public Color purple = new Color(.85f, .14f, 1, 1);
    public Color peach = new Color(1, .70f, .37f, 1);
    public Color pink = new Color(1, .72f, .89f, 1);
    public Color grey = new Color(.73f, .73f, .73f, 1);
    public Color orange = new Color(1, .62f, .14f, 1);
    public Color yellow = new Color(1, .94f, .14f, 1);
    public Color brown = new Color(.41f, .22f, .08f, 1);

    public Color[] splitColors;

    public Color[] SplitGreen()
    {
        splitColors = new Color[] { yellow, blue };
        return splitColors;
    }

    public Color[] SplitPurple()
    {
        splitColors = new Color[] { red, blue };
        return splitColors;
    }

    public Color[] SplitWhite()
    {
        splitColors = new Color[] { purple, orange };
        return splitColors;
    }

    public Color[] SplitOrange()
    {
        splitColors = new Color[] { yellow, red };
        return splitColors;
    }

    public Color[] SplitBrown()
    {
        splitColors = new Color[] { red, green };
        return splitColors;
    }

    public Color CombineColors(Color col1, Color col2)
    {
        return green;
    }

    public Color[] findSplit(Color col)
    {
        if (col == green)
        {
            return SplitGreen();
        } else if (col == purple)
        {
            return SplitPurple();
        } else if (col == white)
        {
            return SplitWhite();
        } else if (col == orange)
        {
            return SplitOrange();
        } else if (col == brown)
        {
            return SplitBrown();
        }
        return null;
    }

}
