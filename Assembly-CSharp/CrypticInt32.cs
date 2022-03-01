using System;

// Token: 0x02000226 RID: 550
public struct CrypticInt32
{
	// Token: 0x06001249 RID: 4681 RVA: 0x000636DA File Offset: 0x00061ADA
	public CrypticInt32(int nValue)
	{
		this._Decrypt = FrameRandom2.GetSeed();
		FrameRandom2.ChangeSeed();
		this._Cryptic = (nValue ^ this._Decrypt);
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x000636FA File Offset: 0x00061AFA
	public int ToInt()
	{
		return this;
	}

	// Token: 0x0600124B RID: 4683 RVA: 0x00063707 File Offset: 0x00061B07
	public uint ToUint()
	{
		return (uint)this;
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x00063714 File Offset: 0x00061B14
	public override string ToString()
	{
		return this.ToInt().ToString();
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x00063738 File Offset: 0x00061B38
	public string ToUintString()
	{
		return this.ToUint().ToString();
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x00063759 File Offset: 0x00061B59
	public static implicit operator CrypticInt32(int nValue)
	{
		return new CrypticInt32(nValue);
	}

	// Token: 0x0600124F RID: 4687 RVA: 0x00063761 File Offset: 0x00061B61
	public static implicit operator int(CrypticInt32 inData)
	{
		return inData._Cryptic ^ inData._Decrypt;
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x00063772 File Offset: 0x00061B72
	public static explicit operator uint(CrypticInt32 inData)
	{
		return (uint)(inData._Cryptic ^ inData._Decrypt);
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x00063783 File Offset: 0x00061B83
	public static explicit operator ushort(CrypticInt32 inData)
	{
		return (ushort)(inData._Cryptic ^ inData._Decrypt);
	}

	// Token: 0x06001252 RID: 4690 RVA: 0x00063795 File Offset: 0x00061B95
	public static explicit operator float(CrypticInt32 inData)
	{
		return (float)(inData._Cryptic ^ inData._Decrypt);
	}

	// Token: 0x04000C34 RID: 3124
	private int _Decrypt;

	// Token: 0x04000C35 RID: 3125
	private int _Cryptic;
}
