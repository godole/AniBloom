using System;
using System.Collections.Generic;

[Serializable]
public class MapData
{
    [Serializable]
    public class NormalObjectlData
    {
        public string ObjectType;
        public int PositionX;
        public int PositionY;
        public int Width;
        public int Height;

        public Dictionary<string, string> ToObjectData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["objectType"] = ObjectType != "" ? ObjectType : "ground";
            d["positionX"] = PositionX.ToString();
            d["positionY"] = PositionY.ToString();
            d["width"] = Width.ToString();
            d["height"] = Height.ToString();

            return d;
        }

        public NormalObjectlData(Dictionary<string, string> d)
        {
            ObjectType = d["objectType"];
            PositionX = Convert.ToInt32(d["positionX"]);
            PositionY = Convert.ToInt32(d["positionY"]);
            Width = Convert.ToInt32(d["width"]);
            Height = Convert.ToInt32(d["height"]);
        }
    }
    [Serializable]
    public class NiddleObjectData
    {
        public int PositionX;
        public int PositionY;
        public int Count;
        public bool IsFlip;

        public Dictionary<string, string> ToObjectData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["objectType"] = "niddle";
            d["positionX"] = PositionX.ToString();
            d["positionY"] = PositionY.ToString();
            d["count"] = Count.ToString();
            d["isFilp"] = IsFlip.ToString();

            return d;
        }

        public NiddleObjectData(Dictionary<string, string> d)
        {
            PositionX = Convert.ToInt32(d["positionX"]);
            PositionY = Convert.ToInt32(d["positionY"]);
            Count = Convert.ToInt32(d["count"]);
            IsFlip = Convert.ToBoolean(d["isFilp"]);
        }
    }
    [Serializable]
    public class RopeObjectData
    {
        public int PositionX;
        public int PositionY;
        public int HitPosX;
        public int HitPosY;
        public double Angle;
        public int Length;

        public Dictionary<string, string> ToObjectData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["objectType"] = "rope";
            d["positionX"] = PositionX.ToString();
            d["positionY"] = PositionY.ToString();
            d["hitPosX"] = HitPosX.ToString();
            d["hitPosY"] = HitPosY.ToString();
            d["angle"] = Angle.ToString();
            d["length"] = Length.ToString();

            return d;
        }

        public RopeObjectData(Dictionary<string, string> d)
        {
            PositionX = Convert.ToInt32(d["positionX"]);
            PositionY = Convert.ToInt32(d["positionY"]);
            HitPosX = Convert.ToInt32(d["hitPosX"]);
            HitPosY = Convert.ToInt32(d["hitPosY"]);
            Angle = Convert.ToDouble(d["angle"]);
            Length = Convert.ToInt32(d["length"]);
        }
    }
    [Serializable]
    public class SpringObjectData
    {
        public int PositionX;
        public int PositionY;
        public int SizeCount;
        public int Count;
        public bool IsUpStart;

        public Dictionary<string, string> ToObjectData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["objectType"] = "spring";
            d["positionX"] = PositionX.ToString();
            d["positionY"] = PositionY.ToString();
            d["sizeCount"] = SizeCount.ToString();
            d["count"] = Count.ToString();
            d["isUpStart"] = IsUpStart.ToString();

            return d;
        }

        public SpringObjectData(Dictionary<string, string> d)
        {
            PositionX = Convert.ToInt32(d["positionX"]);
            PositionY = Convert.ToInt32(d["positionY"]);
            SizeCount = Convert.ToInt32(d["sizeCount"]);
            Count = Convert.ToInt32(d["count"]);
            IsUpStart = Convert.ToBoolean(d["isUpStart"]);
        }
    }
    [Serializable]
    public class GroundObjectData
    {
        public int[] HoleList;
        public int GroundY;
    }

    [Serializable]
    public class CutsceneData
    {
        public string FileName;
        public double Start;
        public double Length;
    }

    [Serializable]
    public class PlatformObjectData
    {
        public int PositionX;
        public int PositionY;
        public int Count;

        public Dictionary<string, string> ToObjectData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["objectType"] = "platform";
            d["positionX"] = PositionX.ToString();
            d["positionY"] = PositionY.ToString();
            d["count"] = Count.ToString();

            return d;
        }

        public PlatformObjectData(Dictionary<string, string> d)
        {
            PositionX = Convert.ToInt32(d["positionX"]);
            PositionY = Convert.ToInt32(d["positionY"]);
            Count = Convert.ToInt32(d["count"]);
        }
    }

    public NormalObjectlData[] NormalObjectList;
    public NormalObjectlData[] GroundObjectList;
    public NiddleObjectData[] NiddleObjectList;
    public RopeObjectData[] RopeObjectList;
    public SpringObjectData[] SpringObjectList;
    public GroundObjectData GroundData;
    public PlatformObjectData[] PlatformObjectList;
    public CutsceneData[] _CutsceneData;

    public int MapLength;
    public string MapName;
    public int BPM;

    public MapData()
    {
        GroundData = new GroundObjectData();
    }
}





