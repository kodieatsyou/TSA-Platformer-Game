using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Colors : MonoBehaviour {

    public Color myred = new Color(1, 0, 0, 1);
    public Color myblue = new Color(0, 0, 1, 1);
    public Color mygreen = new Color(0, 1, 0, 1);
    public Color mywhite = new Color(1, 1, 1, 1);
    public Color myblack = new Color(0, 0, 0, 1);
    public Color mypurple = new Color(.85f, .14f, 1, 1);
    public Color mypeach = new Color(1, .70f, .37f, 1);
    public Color mypink = new Color(1, .72f, .89f, 1);
    public Color mygrey = new Color(.73f, .73f, .73f, 1);
    public Color myorange = new Color(1, .62f, .14f, 1);
    public Color myyellow = new Color(1, .94f, .14f, 1);
    public Color mybrown = new Color(.41f, .22f, .08f, 1);

    public Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>();
  
    public Color[] splitColors;

    public void initDict()
    {
        colorDictionary.Add("white", mywhite);
        colorDictionary["black"] = myblack;
        colorDictionary["blue"] = myblue;
        colorDictionary["green"] = mygreen;
        colorDictionary["white"] = mywhite;
        colorDictionary["purple"] = mypurple;
        colorDictionary["peach"] = mypeach;
        colorDictionary["pink"] = mypink;
        colorDictionary["grey"] = mygrey;
        colorDictionary["orange"] = myorange;
        colorDictionary["yellow"] = myyellow;
        colorDictionary["brown"] = mybrown;
    }

    public Color CombineColorsFam(Color col1, Color col2)
    {
        if ((col1 == myblue && col2 == myyellow) || (col1 == myyellow && col2 == myblue))
        {
            return mygreen;
        } else if ((col1 == mygreen && col2 == myred) || (col1 == myred && col2 == mygreen))
        {
            return mybrown;
        } else if ((col1 == myyellow && col2 == myred) || (col1 == myred && col2 == myyellow))
        {
            return myorange;
        } else if ((col1 == myred && col2 == myblue) || (col1 == myblue && col2 == myred))
        {
            return mypurple;
        } else if ((col1 == myorange && col2 == mypurple) || (col1 == mypurple && col2 == myorange))
        {
            return mywhite;
        } else
        {
            return Color.magenta;
        }
    }

    public Color[] SplitGreen()
    {
        splitColors = new Color[] { myyellow, myblue };
        return splitColors;
    }

    public Color[] SplitPurple()
    {
        splitColors = new Color[] { myred, myblue };
        return splitColors;
    }

    public Color[] SplitWhite()
    {
        splitColors = new Color[] { mypurple, myorange };
        return splitColors;
    }

    public Color[] SplitOrange()
    {
        splitColors = new Color[] { myyellow, myred };
        return splitColors;
    }

    public Color[] SplitBrown()
    {
        splitColors = new Color[] { myred, mygreen };
        return splitColors;
    }

    public Color[] findSplit(Color col)
    {
        if (col == mygreen)
        {
            return SplitGreen();
        } else if (col == mypurple)
        {
            return SplitPurple();
        } else if (col == mywhite)
        {
            return SplitWhite();
        } else if (col == myorange)
        {
            return SplitOrange();
        } else if (col == mybrown)
        {
            return SplitBrown();
        }
        return null;
    }

    public Color findColor(string name)
    {
        if(name == "1")
        {
            return myblack;
        }
        if (name == myblue.ToString())
        {
            return myblue;
        }
        if (name == mygreen.ToString())
        {
            return mygreen;
        }
        if (name == mywhite.ToString())
        {
            return mywhite;
        }
        if (name == mypurple.ToString())
        {
            return mypurple;
        }
        if (name == mypeach.ToString())
        {
            return mypeach;
        }
        if (name == mypink.ToString())
        {
            return mypink;
        }
        if (name == mygrey.ToString())
        {
            return mygrey;
        }
        if (name == myorange.ToString())
        {
            return myorange;
        }
        if (name == myyellow.ToString())
        {
            return myyellow;
        } else
        {
            return mybrown;
        }
    }

}
