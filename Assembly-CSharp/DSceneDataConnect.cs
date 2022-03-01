using System;

// Token: 0x02004B5B RID: 19291
[Serializable]
public class DSceneDataConnect : IDungeonConnectData
{
	// Token: 0x0601C5E3 RID: 116195 RVA: 0x0089D349 File Offset: 0x0089B749
	public bool[] GetIsConnect()
	{
		return this.isconnect;
	}

	// Token: 0x0601C5E4 RID: 116196 RVA: 0x0089D351 File Offset: 0x0089B751
	public int GetAreaIndex()
	{
		return this.areaindex;
	}

	// Token: 0x0601C5E5 RID: 116197 RVA: 0x0089D359 File Offset: 0x0089B759
	public int GetId()
	{
		return this.id;
	}

	// Token: 0x0601C5E6 RID: 116198 RVA: 0x0089D361 File Offset: 0x0089B761
	public string GetSceneAreaPath()
	{
		return this.sceneareapath;
	}

	// Token: 0x0601C5E7 RID: 116199 RVA: 0x0089D369 File Offset: 0x0089B769
	public void SetSceneAreaPath(string path)
	{
		this.sceneareapath = path;
	}

	// Token: 0x0601C5E8 RID: 116200 RVA: 0x0089D372 File Offset: 0x0089B772
	public int GetPositionX()
	{
		return this.positionx;
	}

	// Token: 0x0601C5E9 RID: 116201 RVA: 0x0089D37A File Offset: 0x0089B77A
	public int GetPositionY()
	{
		return this.positiony;
	}

	// Token: 0x0601C5EA RID: 116202 RVA: 0x0089D382 File Offset: 0x0089B782
	public bool IsBoss()
	{
		return this.isboss;
	}

	// Token: 0x0601C5EB RID: 116203 RVA: 0x0089D38A File Offset: 0x0089B78A
	public bool IsStart()
	{
		return this.isstart;
	}

	// Token: 0x0601C5EC RID: 116204 RVA: 0x0089D392 File Offset: 0x0089B792
	public bool IsEgg()
	{
		return this.isegg;
	}

	// Token: 0x0601C5ED RID: 116205 RVA: 0x0089D39A File Offset: 0x0089B79A
	public bool IsNotHell()
	{
		return this.isnothell;
	}

	// Token: 0x0601C5EE RID: 116206 RVA: 0x0089D3A2 File Offset: 0x0089B7A2
	public int GetIsConnectLength()
	{
		if (this.isconnect == null)
		{
			return 0;
		}
		return this.isconnect.Length;
	}

	// Token: 0x0601C5EF RID: 116207 RVA: 0x0089D3B9 File Offset: 0x0089B7B9
	public bool GetIsConnect(int i)
	{
		return this.isconnect != null && i >= 0 && i < this.GetIsConnectLength() && this.isconnect[i];
	}

	// Token: 0x0601C5F0 RID: 116208 RVA: 0x0089D3E7 File Offset: 0x0089B7E7
	public void SetSceneData(ISceneData sceneData)
	{
		this.scenedata = (sceneData as DSceneData);
	}

	// Token: 0x0601C5F1 RID: 116209 RVA: 0x0089D3F5 File Offset: 0x0089B7F5
	public ISceneData GetSceneData()
	{
		return this.scenedata;
	}

	// Token: 0x0601C5F2 RID: 116210 RVA: 0x0089D3FD File Offset: 0x0089B7FD
	public int GetLinkAreaIndexesLength()
	{
		if (this.linkAreaIndex == null)
		{
			return 0;
		}
		return this.linkAreaIndex.Length;
	}

	// Token: 0x0601C5F3 RID: 116211 RVA: 0x0089D414 File Offset: 0x0089B814
	public int GetLinkAreaIndex(int i)
	{
		int linkAreaIndexesLength = this.GetLinkAreaIndexesLength();
		if (i < 0)
		{
			return -1;
		}
		if (i >= linkAreaIndexesLength)
		{
			return -1;
		}
		return this.linkAreaIndex[i];
	}

	// Token: 0x0601C5F4 RID: 116212 RVA: 0x0089D442 File Offset: 0x0089B842
	public byte GetTreasureType()
	{
		return this.treasureType;
	}

	// Token: 0x0401380B RID: 79883
	public bool[] isconnect = new bool[4];

	// Token: 0x0401380C RID: 79884
	public int areaindex = -1;

	// Token: 0x0401380D RID: 79885
	public int[] linkAreaIndex = new int[0];

	// Token: 0x0401380E RID: 79886
	public int id;

	// Token: 0x0401380F RID: 79887
	public string sceneareapath = string.Empty;

	// Token: 0x04013810 RID: 79888
	[NonSerialized]
	public DSceneData scenedata;

	// Token: 0x04013811 RID: 79889
	public int positionx = -1;

	// Token: 0x04013812 RID: 79890
	public int positiony = -1;

	// Token: 0x04013813 RID: 79891
	public bool isboss;

	// Token: 0x04013814 RID: 79892
	public bool isstart;

	// Token: 0x04013815 RID: 79893
	public bool isegg;

	// Token: 0x04013816 RID: 79894
	public bool isnothell;

	// Token: 0x04013817 RID: 79895
	public byte treasureType;
}
