using System;
using UnityEngine;

// Token: 0x02004BD9 RID: 19417
public class TileMapConstant
{
	// Token: 0x0601C78D RID: 116621 RVA: 0x0089F848 File Offset: 0x0089DC48
	public static TilePos UIPos2TilePos(Vector2 pos)
	{
		int num = Mathf.RoundToInt(pos.y / 90f);
		int x = Mathf.RoundToInt(pos.x / 115f - (float)num / 2f);
		return new TilePos(x, num);
	}

	// Token: 0x0601C78E RID: 116622 RVA: 0x0089F88C File Offset: 0x0089DC8C
	public static Vector3 TilePos2UIPos(TilePos pos)
	{
		float num = (float)pos.Y * 90f;
		float num2 = ((float)pos.X + (float)pos.Y / 2f) * 115f;
		return new Vector3(num2, num, 0f);
	}

	// Token: 0x04013ADD RID: 80605
	public const int skTileWidth = 110;

	// Token: 0x04013ADE RID: 80606
	public const int skTileHeight = 160;

	// Token: 0x04013ADF RID: 80607
	public const float skTileXOffset = 115f;

	// Token: 0x04013AE0 RID: 80608
	public const float skTileYOffset = 90f;

	// Token: 0x04013AE1 RID: 80609
	public const string skAssetPrefix = "Assets/Resources/";

	// Token: 0x04013AE2 RID: 80610
	public const string skTileDataRoot = "Data/TileData/";

	// Token: 0x04013AE3 RID: 80611
	public const string skTileResDataPath = "Data/TileData/Res.asset";

	// Token: 0x04013AE4 RID: 80612
	public const string skTileMapDataPath = "Data/TileData/Map.asset";

	// Token: 0x04013AE5 RID: 80613
	public const string skTileResDataPathInEditor = "Assets/Resources/Data/TileData/Res.asset";

	// Token: 0x04013AE6 RID: 80614
	public const string skTileMapDataPathInEditor = "Assets/Resources/Data/TileData/Map.asset";
}
