using System;
using UnityEngine;

// Token: 0x02000227 RID: 551
[Serializable]
public struct CrypticUlong : IFormattable, IConvertible, IComparable, IComparable<CrypticUlong>, IEquatable<CrypticUlong>
{
	// Token: 0x06001253 RID: 4691 RVA: 0x000637A7 File Offset: 0x00061BA7
	public CrypticUlong(ulong nValue)
	{
		this.cryptoKey = 544443UL;
		this.hiddenValue = CrypticUlong.Encrypt(nValue, this.cryptoKey);
		this.fakeValue = nValue;
		this.inited = true;
	}

	// Token: 0x06001254 RID: 4692 RVA: 0x000637D5 File Offset: 0x00061BD5
	private static ulong Encrypt(ulong value, ulong key)
	{
		return value ^ key;
	}

	// Token: 0x06001255 RID: 4693 RVA: 0x000637DA File Offset: 0x00061BDA
	private static ulong Decrypt(ulong value, ulong key)
	{
		return value ^ key;
	}

	// Token: 0x06001256 RID: 4694 RVA: 0x000637E0 File Offset: 0x00061BE0
	private ulong InternalDecrypt()
	{
		if (!this.inited)
		{
			this.cryptoKey = 544443UL;
			this.hiddenValue = CrypticUlong.Encrypt(0UL, this.cryptoKey);
			this.fakeValue = 0UL;
			this.inited = true;
		}
		ulong num = CrypticUlong.Decrypt(this.hiddenValue, this.cryptoKey);
		if (num != this.fakeValue)
		{
			MonoSingleton<CheatMonitor>.instance.OnCheatingDetected();
			return 0UL;
		}
		return num;
	}

	// Token: 0x06001257 RID: 4695 RVA: 0x00063852 File Offset: 0x00061C52
	public static implicit operator CrypticUlong(ulong nValue)
	{
		return new CrypticUlong(nValue);
	}

	// Token: 0x06001258 RID: 4696 RVA: 0x0006385A File Offset: 0x00061C5A
	public static implicit operator ulong(CrypticUlong inData)
	{
		return inData.InternalDecrypt();
	}

	// Token: 0x06001259 RID: 4697 RVA: 0x00063863 File Offset: 0x00061C63
	public static explicit operator int(CrypticUlong inData)
	{
		return (int)inData.InternalDecrypt();
	}

	// Token: 0x0600125A RID: 4698 RVA: 0x0006386D File Offset: 0x00061C6D
	public static explicit operator uint(CrypticUlong inData)
	{
		return (uint)inData.InternalDecrypt();
	}

	// Token: 0x0600125B RID: 4699 RVA: 0x00063877 File Offset: 0x00061C77
	public static explicit operator ushort(CrypticUlong inData)
	{
		return (ushort)inData.InternalDecrypt();
	}

	// Token: 0x0600125C RID: 4700 RVA: 0x00063881 File Offset: 0x00061C81
	public static explicit operator float(CrypticUlong inData)
	{
		return inData.InternalDecrypt();
	}

	// Token: 0x0600125D RID: 4701 RVA: 0x0006388C File Offset: 0x00061C8C
	public static CrypticUlong operator ++(CrypticUlong inData)
	{
		ulong value = inData.InternalDecrypt() + 1UL;
		inData.hiddenValue = CrypticUlong.Encrypt(value, inData.cryptoKey);
		inData.fakeValue = value;
		return inData;
	}

	// Token: 0x0600125E RID: 4702 RVA: 0x000638C4 File Offset: 0x00061CC4
	public static CrypticUlong operator --(CrypticUlong inData)
	{
		ulong value = inData.InternalDecrypt() - 1UL;
		inData.hiddenValue = CrypticUlong.Encrypt(value, inData.cryptoKey);
		inData.fakeValue = value;
		return inData;
	}

	// Token: 0x0600125F RID: 4703 RVA: 0x000638F9 File Offset: 0x00061CF9
	public override bool Equals(object obj)
	{
		return obj is CrypticUlong && this.Equals((CrypticUlong)obj);
	}

	// Token: 0x06001260 RID: 4704 RVA: 0x00063914 File Offset: 0x00061D14
	public bool Equals(CrypticUlong obj)
	{
		if (this.cryptoKey == obj.cryptoKey)
		{
			return this.hiddenValue == obj.hiddenValue;
		}
		return CrypticUlong.Decrypt(this.hiddenValue, this.cryptoKey) == CrypticUlong.Decrypt(obj.hiddenValue, obj.cryptoKey);
	}

	// Token: 0x06001261 RID: 4705 RVA: 0x0006396C File Offset: 0x00061D6C
	public override int GetHashCode()
	{
		return this.InternalDecrypt().GetHashCode();
	}

	// Token: 0x06001262 RID: 4706 RVA: 0x00063990 File Offset: 0x00061D90
	public override string ToString()
	{
		return this.InternalDecrypt().ToString();
	}

	// Token: 0x06001263 RID: 4707 RVA: 0x000639B4 File Offset: 0x00061DB4
	public string ToString(string format)
	{
		return this.InternalDecrypt().ToString(format);
	}

	// Token: 0x06001264 RID: 4708 RVA: 0x000639D0 File Offset: 0x00061DD0
	public string ToString(IFormatProvider provider)
	{
		return this.InternalDecrypt().ToString(provider);
	}

	// Token: 0x06001265 RID: 4709 RVA: 0x000639EC File Offset: 0x00061DEC
	public string ToString(string format, IFormatProvider provider)
	{
		return this.InternalDecrypt().ToString(format, provider);
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x00063A0C File Offset: 0x00061E0C
	public int CompareTo(CrypticUlong other)
	{
		return this.InternalDecrypt().CompareTo(other.InternalDecrypt());
	}

	// Token: 0x06001267 RID: 4711 RVA: 0x00063A30 File Offset: 0x00061E30
	public int CompareTo(int other)
	{
		return this.InternalDecrypt().CompareTo(other);
	}

	// Token: 0x06001268 RID: 4712 RVA: 0x00063A51 File Offset: 0x00061E51
	public int CompareTo(object obj)
	{
		if (!(obj is CrypticUlong))
		{
			throw new ArgumentException("obj is not CrypticUlong");
		}
		return this.CompareTo((CrypticUlong)obj);
	}

	// Token: 0x06001269 RID: 4713 RVA: 0x00063A78 File Offset: 0x00061E78
	public TypeCode GetTypeCode()
	{
		return this.InternalDecrypt().GetTypeCode();
	}

	// Token: 0x0600126A RID: 4714 RVA: 0x00063A93 File Offset: 0x00061E93
	public bool ToBoolean(IFormatProvider provider)
	{
		return Convert.ToBoolean(this.InternalDecrypt(), provider);
	}

	// Token: 0x0600126B RID: 4715 RVA: 0x00063AA6 File Offset: 0x00061EA6
	public byte ToByte(IFormatProvider provider)
	{
		return Convert.ToByte(this.InternalDecrypt(), provider);
	}

	// Token: 0x0600126C RID: 4716 RVA: 0x00063AB9 File Offset: 0x00061EB9
	public char ToChar(IFormatProvider provider)
	{
		return Convert.ToChar(this.InternalDecrypt(), provider);
	}

	// Token: 0x0600126D RID: 4717 RVA: 0x00063ACC File Offset: 0x00061ECC
	public DateTime ToDateTime(IFormatProvider provider)
	{
		throw new InvalidCastException();
	}

	// Token: 0x0600126E RID: 4718 RVA: 0x00063AD3 File Offset: 0x00061ED3
	public decimal ToDecimal(IFormatProvider provider)
	{
		return Convert.ToDecimal(this.InternalDecrypt(), provider);
	}

	// Token: 0x0600126F RID: 4719 RVA: 0x00063AE6 File Offset: 0x00061EE6
	public double ToDouble(IFormatProvider provider)
	{
		return Convert.ToDouble(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x00063AF9 File Offset: 0x00061EF9
	public short ToInt16(IFormatProvider provider)
	{
		return Convert.ToInt16(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001271 RID: 4721 RVA: 0x00063B0C File Offset: 0x00061F0C
	public int ToInt32(IFormatProvider provider)
	{
		return Convert.ToInt32(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001272 RID: 4722 RVA: 0x00063B1F File Offset: 0x00061F1F
	public long ToInt64(IFormatProvider provider)
	{
		return Convert.ToInt64(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001273 RID: 4723 RVA: 0x00063B32 File Offset: 0x00061F32
	public sbyte ToSByte(IFormatProvider provider)
	{
		return Convert.ToSByte(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001274 RID: 4724 RVA: 0x00063B45 File Offset: 0x00061F45
	public float ToSingle(IFormatProvider provider)
	{
		return Convert.ToSingle(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001275 RID: 4725 RVA: 0x00063B58 File Offset: 0x00061F58
	public object ToType(Type conversionType, IFormatProvider provider)
	{
		return Convert.ChangeType(this.InternalDecrypt(), conversionType, provider);
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x00063B6C File Offset: 0x00061F6C
	public ushort ToUInt16(IFormatProvider provider)
	{
		return Convert.ToUInt16(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001277 RID: 4727 RVA: 0x00063B7F File Offset: 0x00061F7F
	public uint ToUInt32(IFormatProvider provider)
	{
		return Convert.ToUInt32(this.InternalDecrypt(), provider);
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x00063B92 File Offset: 0x00061F92
	public ulong ToUInt64(IFormatProvider provider)
	{
		return Convert.ToUInt64(this.InternalDecrypt(), provider);
	}

	// Token: 0x04000C36 RID: 3126
	[SerializeField]
	private ulong cryptoKey;

	// Token: 0x04000C37 RID: 3127
	[SerializeField]
	private ulong hiddenValue;

	// Token: 0x04000C38 RID: 3128
	[SerializeField]
	private ulong fakeValue;

	// Token: 0x04000C39 RID: 3129
	[SerializeField]
	private bool inited;
}
