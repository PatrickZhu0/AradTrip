using System;

// Token: 0x02000DED RID: 3565
public class UIFrameSound : Attribute
{
	// Token: 0x06008F63 RID: 36707 RVA: 0x001A8AA1 File Offset: 0x001A6EA1
	public UIFrameSound(string name, string sound = "Sound/SE/click1")
	{
		this.name = name;
		this.sound = sound;
		this.bNeed = true;
	}

	// Token: 0x06008F64 RID: 36708 RVA: 0x001A8ABE File Offset: 0x001A6EBE
	public UIFrameSound(string name, bool bNeed)
	{
		this.name = name;
		this.sound = "Sound/SE/click1";
		this.bNeed = bNeed;
	}

	// Token: 0x06008F65 RID: 36709 RVA: 0x001A8ADF File Offset: 0x001A6EDF
	public void OnPlaySound()
	{
		if (this.bNeed)
		{
		}
	}

	// Token: 0x04004733 RID: 18227
	public string name;

	// Token: 0x04004734 RID: 18228
	public string sound;

	// Token: 0x04004735 RID: 18229
	public bool bNeed;
}
