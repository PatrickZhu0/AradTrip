using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200040C RID: 1036
	public class EquipStrModTable : IFlatbufferObject
	{
		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x06002FDF RID: 12255 RVA: 0x000AC0D0 File Offset: 0x000AA4D0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002FE0 RID: 12256 RVA: 0x000AC0DD File Offset: 0x000AA4DD
		public static EquipStrModTable GetRootAsEquipStrModTable(ByteBuffer _bb)
		{
			return EquipStrModTable.GetRootAsEquipStrModTable(_bb, new EquipStrModTable());
		}

		// Token: 0x06002FE1 RID: 12257 RVA: 0x000AC0EA File Offset: 0x000AA4EA
		public static EquipStrModTable GetRootAsEquipStrModTable(ByteBuffer _bb, EquipStrModTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002FE2 RID: 12258 RVA: 0x000AC106 File Offset: 0x000AA506
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002FE3 RID: 12259 RVA: 0x000AC120 File Offset: 0x000AA520
		public EquipStrModTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x06002FE4 RID: 12260 RVA: 0x000AC12C File Offset: 0x000AA52C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002FE5 RID: 12261 RVA: 0x000AC178 File Offset: 0x000AA578
		public int WpStrenthModArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x06002FE6 RID: 12262 RVA: 0x000AC1C4 File Offset: 0x000AA5C4
		public int WpStrenthModLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FE7 RID: 12263 RVA: 0x000AC1F6 File Offset: 0x000AA5F6
		public ArraySegment<byte>? GetWpStrenthModBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x06002FE8 RID: 12264 RVA: 0x000AC204 File Offset: 0x000AA604
		public FlatBufferArray<int> WpStrenthMod
		{
			get
			{
				if (this.WpStrenthModValue == null)
				{
					this.WpStrenthModValue = new FlatBufferArray<int>(new Func<int, int>(this.WpStrenthModArray), this.WpStrenthModLength);
				}
				return this.WpStrenthModValue;
			}
		}

		// Token: 0x06002FE9 RID: 12265 RVA: 0x000AC234 File Offset: 0x000AA634
		public int WpColorQaModArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x06002FEA RID: 12266 RVA: 0x000AC280 File Offset: 0x000AA680
		public int WpColorQaModLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FEB RID: 12267 RVA: 0x000AC2B2 File Offset: 0x000AA6B2
		public ArraySegment<byte>? GetWpColorQaModBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x06002FEC RID: 12268 RVA: 0x000AC2C0 File Offset: 0x000AA6C0
		public FlatBufferArray<int> WpColorQaMod
		{
			get
			{
				if (this.WpColorQaModValue == null)
				{
					this.WpColorQaModValue = new FlatBufferArray<int>(new Func<int, int>(this.WpColorQaModArray), this.WpColorQaModLength);
				}
				return this.WpColorQaModValue;
			}
		}

		// Token: 0x06002FED RID: 12269 RVA: 0x000AC2F0 File Offset: 0x000AA6F0
		public int WpColorQbModArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x06002FEE RID: 12270 RVA: 0x000AC340 File Offset: 0x000AA740
		public int WpColorQbModLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FEF RID: 12271 RVA: 0x000AC373 File Offset: 0x000AA773
		public ArraySegment<byte>? GetWpColorQbModBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x06002FF0 RID: 12272 RVA: 0x000AC382 File Offset: 0x000AA782
		public FlatBufferArray<int> WpColorQbMod
		{
			get
			{
				if (this.WpColorQbModValue == null)
				{
					this.WpColorQbModValue = new FlatBufferArray<int>(new Func<int, int>(this.WpColorQbModArray), this.WpColorQbModLength);
				}
				return this.WpColorQbModValue;
			}
		}

		// Token: 0x06002FF1 RID: 12273 RVA: 0x000AC3B4 File Offset: 0x000AA7B4
		public int ArmStrenthModArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x06002FF2 RID: 12274 RVA: 0x000AC404 File Offset: 0x000AA804
		public int ArmStrenthModLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x000AC437 File Offset: 0x000AA837
		public ArraySegment<byte>? GetArmStrenthModBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06002FF4 RID: 12276 RVA: 0x000AC446 File Offset: 0x000AA846
		public FlatBufferArray<int> ArmStrenthMod
		{
			get
			{
				if (this.ArmStrenthModValue == null)
				{
					this.ArmStrenthModValue = new FlatBufferArray<int>(new Func<int, int>(this.ArmStrenthModArray), this.ArmStrenthModLength);
				}
				return this.ArmStrenthModValue;
			}
		}

		// Token: 0x06002FF5 RID: 12277 RVA: 0x000AC478 File Offset: 0x000AA878
		public int ArmColorQaModArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06002FF6 RID: 12278 RVA: 0x000AC4C8 File Offset: 0x000AA8C8
		public int ArmColorQaModLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FF7 RID: 12279 RVA: 0x000AC4FB File Offset: 0x000AA8FB
		public ArraySegment<byte>? GetArmColorQaModBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x06002FF8 RID: 12280 RVA: 0x000AC50A File Offset: 0x000AA90A
		public FlatBufferArray<int> ArmColorQaMod
		{
			get
			{
				if (this.ArmColorQaModValue == null)
				{
					this.ArmColorQaModValue = new FlatBufferArray<int>(new Func<int, int>(this.ArmColorQaModArray), this.ArmColorQaModLength);
				}
				return this.ArmColorQaModValue;
			}
		}

		// Token: 0x06002FF9 RID: 12281 RVA: 0x000AC53C File Offset: 0x000AA93C
		public int ArmColorQbModArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x06002FFA RID: 12282 RVA: 0x000AC58C File Offset: 0x000AA98C
		public int ArmColorQbModLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FFB RID: 12283 RVA: 0x000AC5BF File Offset: 0x000AA9BF
		public ArraySegment<byte>? GetArmColorQbModBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x06002FFC RID: 12284 RVA: 0x000AC5CE File Offset: 0x000AA9CE
		public FlatBufferArray<int> ArmColorQbMod
		{
			get
			{
				if (this.ArmColorQbModValue == null)
				{
					this.ArmColorQbModValue = new FlatBufferArray<int>(new Func<int, int>(this.ArmColorQbModArray), this.ArmColorQbModLength);
				}
				return this.ArmColorQbModValue;
			}
		}

		// Token: 0x06002FFD RID: 12285 RVA: 0x000AC600 File Offset: 0x000AAA00
		public int JewStrenthModArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x06002FFE RID: 12286 RVA: 0x000AC650 File Offset: 0x000AAA50
		public int JewStrenthModLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002FFF RID: 12287 RVA: 0x000AC683 File Offset: 0x000AAA83
		public ArraySegment<byte>? GetJewStrenthModBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06003000 RID: 12288 RVA: 0x000AC692 File Offset: 0x000AAA92
		public FlatBufferArray<int> JewStrenthMod
		{
			get
			{
				if (this.JewStrenthModValue == null)
				{
					this.JewStrenthModValue = new FlatBufferArray<int>(new Func<int, int>(this.JewStrenthModArray), this.JewStrenthModLength);
				}
				return this.JewStrenthModValue;
			}
		}

		// Token: 0x06003001 RID: 12289 RVA: 0x000AC6C4 File Offset: 0x000AAAC4
		public int JewColorQaModArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06003002 RID: 12290 RVA: 0x000AC714 File Offset: 0x000AAB14
		public int JewColorQaModLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003003 RID: 12291 RVA: 0x000AC747 File Offset: 0x000AAB47
		public ArraySegment<byte>? GetJewColorQaModBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06003004 RID: 12292 RVA: 0x000AC756 File Offset: 0x000AAB56
		public FlatBufferArray<int> JewColorQaMod
		{
			get
			{
				if (this.JewColorQaModValue == null)
				{
					this.JewColorQaModValue = new FlatBufferArray<int>(new Func<int, int>(this.JewColorQaModArray), this.JewColorQaModLength);
				}
				return this.JewColorQaModValue;
			}
		}

		// Token: 0x06003005 RID: 12293 RVA: 0x000AC788 File Offset: 0x000AAB88
		public int JewColorQbModArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x06003006 RID: 12294 RVA: 0x000AC7D8 File Offset: 0x000AABD8
		public int JewColorQbModLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003007 RID: 12295 RVA: 0x000AC80B File Offset: 0x000AAC0B
		public ArraySegment<byte>? GetJewColorQbModBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x06003008 RID: 12296 RVA: 0x000AC81A File Offset: 0x000AAC1A
		public FlatBufferArray<int> JewColorQbMod
		{
			get
			{
				if (this.JewColorQbModValue == null)
				{
					this.JewColorQbModValue = new FlatBufferArray<int>(new Func<int, int>(this.JewColorQbModArray), this.JewColorQbModLength);
				}
				return this.JewColorQbModValue;
			}
		}

		// Token: 0x06003009 RID: 12297 RVA: 0x000AC84C File Offset: 0x000AAC4C
		public int HugeSwordArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x0600300A RID: 12298 RVA: 0x000AC89C File Offset: 0x000AAC9C
		public int HugeSwordLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x000AC8CF File Offset: 0x000AACCF
		public ArraySegment<byte>? GetHugeSwordBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000B96 RID: 2966
		// (get) Token: 0x0600300C RID: 12300 RVA: 0x000AC8DE File Offset: 0x000AACDE
		public FlatBufferArray<int> HugeSword
		{
			get
			{
				if (this.HugeSwordValue == null)
				{
					this.HugeSwordValue = new FlatBufferArray<int>(new Func<int, int>(this.HugeSwordArray), this.HugeSwordLength);
				}
				return this.HugeSwordValue;
			}
		}

		// Token: 0x0600300D RID: 12301 RVA: 0x000AC910 File Offset: 0x000AAD10
		public int KatanaArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x0600300E RID: 12302 RVA: 0x000AC960 File Offset: 0x000AAD60
		public int KatanaLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600300F RID: 12303 RVA: 0x000AC993 File Offset: 0x000AAD93
		public ArraySegment<byte>? GetKatanaBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x06003010 RID: 12304 RVA: 0x000AC9A2 File Offset: 0x000AADA2
		public FlatBufferArray<int> Katana
		{
			get
			{
				if (this.KatanaValue == null)
				{
					this.KatanaValue = new FlatBufferArray<int>(new Func<int, int>(this.KatanaArray), this.KatanaLength);
				}
				return this.KatanaValue;
			}
		}

		// Token: 0x06003011 RID: 12305 RVA: 0x000AC9D4 File Offset: 0x000AADD4
		public int ShortSwordArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x06003012 RID: 12306 RVA: 0x000ACA24 File Offset: 0x000AAE24
		public int ShortSwordLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003013 RID: 12307 RVA: 0x000ACA57 File Offset: 0x000AAE57
		public ArraySegment<byte>? GetShortSwordBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x06003014 RID: 12308 RVA: 0x000ACA66 File Offset: 0x000AAE66
		public FlatBufferArray<int> ShortSword
		{
			get
			{
				if (this.ShortSwordValue == null)
				{
					this.ShortSwordValue = new FlatBufferArray<int>(new Func<int, int>(this.ShortSwordArray), this.ShortSwordLength);
				}
				return this.ShortSwordValue;
			}
		}

		// Token: 0x06003015 RID: 12309 RVA: 0x000ACA98 File Offset: 0x000AAE98
		public int BeamSwordArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B9B RID: 2971
		// (get) Token: 0x06003016 RID: 12310 RVA: 0x000ACAE8 File Offset: 0x000AAEE8
		public int BeamSwordLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003017 RID: 12311 RVA: 0x000ACB1B File Offset: 0x000AAF1B
		public ArraySegment<byte>? GetBeamSwordBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x06003018 RID: 12312 RVA: 0x000ACB2A File Offset: 0x000AAF2A
		public FlatBufferArray<int> BeamSword
		{
			get
			{
				if (this.BeamSwordValue == null)
				{
					this.BeamSwordValue = new FlatBufferArray<int>(new Func<int, int>(this.BeamSwordArray), this.BeamSwordLength);
				}
				return this.BeamSwordValue;
			}
		}

		// Token: 0x06003019 RID: 12313 RVA: 0x000ACB5C File Offset: 0x000AAF5C
		public int BluntArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x0600301A RID: 12314 RVA: 0x000ACBAC File Offset: 0x000AAFAC
		public int BluntLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600301B RID: 12315 RVA: 0x000ACBDF File Offset: 0x000AAFDF
		public ArraySegment<byte>? GetBluntBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000B9E RID: 2974
		// (get) Token: 0x0600301C RID: 12316 RVA: 0x000ACBEE File Offset: 0x000AAFEE
		public FlatBufferArray<int> Blunt
		{
			get
			{
				if (this.BluntValue == null)
				{
					this.BluntValue = new FlatBufferArray<int>(new Func<int, int>(this.BluntArray), this.BluntLength);
				}
				return this.BluntValue;
			}
		}

		// Token: 0x0600301D RID: 12317 RVA: 0x000ACC20 File Offset: 0x000AB020
		public int RevolverArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x0600301E RID: 12318 RVA: 0x000ACC70 File Offset: 0x000AB070
		public int RevolverLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600301F RID: 12319 RVA: 0x000ACCA3 File Offset: 0x000AB0A3
		public ArraySegment<byte>? GetRevolverBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000BA0 RID: 2976
		// (get) Token: 0x06003020 RID: 12320 RVA: 0x000ACCB2 File Offset: 0x000AB0B2
		public FlatBufferArray<int> Revolver
		{
			get
			{
				if (this.RevolverValue == null)
				{
					this.RevolverValue = new FlatBufferArray<int>(new Func<int, int>(this.RevolverArray), this.RevolverLength);
				}
				return this.RevolverValue;
			}
		}

		// Token: 0x06003021 RID: 12321 RVA: 0x000ACCE4 File Offset: 0x000AB0E4
		public int CrossBowArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BA1 RID: 2977
		// (get) Token: 0x06003022 RID: 12322 RVA: 0x000ACD34 File Offset: 0x000AB134
		public int CrossBowLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003023 RID: 12323 RVA: 0x000ACD67 File Offset: 0x000AB167
		public ArraySegment<byte>? GetCrossBowBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000BA2 RID: 2978
		// (get) Token: 0x06003024 RID: 12324 RVA: 0x000ACD76 File Offset: 0x000AB176
		public FlatBufferArray<int> CrossBow
		{
			get
			{
				if (this.CrossBowValue == null)
				{
					this.CrossBowValue = new FlatBufferArray<int>(new Func<int, int>(this.CrossBowArray), this.CrossBowLength);
				}
				return this.CrossBowValue;
			}
		}

		// Token: 0x06003025 RID: 12325 RVA: 0x000ACDA8 File Offset: 0x000AB1A8
		public int HandCannonArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BA3 RID: 2979
		// (get) Token: 0x06003026 RID: 12326 RVA: 0x000ACDF8 File Offset: 0x000AB1F8
		public int HandCannonLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003027 RID: 12327 RVA: 0x000ACE2B File Offset: 0x000AB22B
		public ArraySegment<byte>? GetHandCannonBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000BA4 RID: 2980
		// (get) Token: 0x06003028 RID: 12328 RVA: 0x000ACE3A File Offset: 0x000AB23A
		public FlatBufferArray<int> HandCannon
		{
			get
			{
				if (this.HandCannonValue == null)
				{
					this.HandCannonValue = new FlatBufferArray<int>(new Func<int, int>(this.HandCannonArray), this.HandCannonLength);
				}
				return this.HandCannonValue;
			}
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x000ACE6C File Offset: 0x000AB26C
		public int AutoRifleArray(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BA5 RID: 2981
		// (get) Token: 0x0600302A RID: 12330 RVA: 0x000ACEBC File Offset: 0x000AB2BC
		public int AutoRifleLength
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x000ACEEF File Offset: 0x000AB2EF
		public ArraySegment<byte>? GetAutoRifleBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17000BA6 RID: 2982
		// (get) Token: 0x0600302C RID: 12332 RVA: 0x000ACEFE File Offset: 0x000AB2FE
		public FlatBufferArray<int> AutoRifle
		{
			get
			{
				if (this.AutoRifleValue == null)
				{
					this.AutoRifleValue = new FlatBufferArray<int>(new Func<int, int>(this.AutoRifleArray), this.AutoRifleLength);
				}
				return this.AutoRifleValue;
			}
		}

		// Token: 0x0600302D RID: 12333 RVA: 0x000ACF30 File Offset: 0x000AB330
		public int AutoPistalArray(int j)
		{
			int num = this.__p.__offset(42);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BA7 RID: 2983
		// (get) Token: 0x0600302E RID: 12334 RVA: 0x000ACF80 File Offset: 0x000AB380
		public int AutoPistalLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600302F RID: 12335 RVA: 0x000ACFB3 File Offset: 0x000AB3B3
		public ArraySegment<byte>? GetAutoPistalBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000BA8 RID: 2984
		// (get) Token: 0x06003030 RID: 12336 RVA: 0x000ACFC2 File Offset: 0x000AB3C2
		public FlatBufferArray<int> AutoPistal
		{
			get
			{
				if (this.AutoPistalValue == null)
				{
					this.AutoPistalValue = new FlatBufferArray<int>(new Func<int, int>(this.AutoPistalArray), this.AutoPistalLength);
				}
				return this.AutoPistalValue;
			}
		}

		// Token: 0x06003031 RID: 12337 RVA: 0x000ACFF4 File Offset: 0x000AB3F4
		public int MagicStickArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x06003032 RID: 12338 RVA: 0x000AD044 File Offset: 0x000AB444
		public int MagicStickLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003033 RID: 12339 RVA: 0x000AD077 File Offset: 0x000AB477
		public ArraySegment<byte>? GetMagicStickBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000BAA RID: 2986
		// (get) Token: 0x06003034 RID: 12340 RVA: 0x000AD086 File Offset: 0x000AB486
		public FlatBufferArray<int> MagicStick
		{
			get
			{
				if (this.MagicStickValue == null)
				{
					this.MagicStickValue = new FlatBufferArray<int>(new Func<int, int>(this.MagicStickArray), this.MagicStickLength);
				}
				return this.MagicStickValue;
			}
		}

		// Token: 0x06003035 RID: 12341 RVA: 0x000AD0B8 File Offset: 0x000AB4B8
		public int TwigArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BAB RID: 2987
		// (get) Token: 0x06003036 RID: 12342 RVA: 0x000AD108 File Offset: 0x000AB508
		public int TwigLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003037 RID: 12343 RVA: 0x000AD13B File Offset: 0x000AB53B
		public ArraySegment<byte>? GetTwigBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000BAC RID: 2988
		// (get) Token: 0x06003038 RID: 12344 RVA: 0x000AD14A File Offset: 0x000AB54A
		public FlatBufferArray<int> Twig
		{
			get
			{
				if (this.TwigValue == null)
				{
					this.TwigValue = new FlatBufferArray<int>(new Func<int, int>(this.TwigArray), this.TwigLength);
				}
				return this.TwigValue;
			}
		}

		// Token: 0x06003039 RID: 12345 RVA: 0x000AD17C File Offset: 0x000AB57C
		public int PikeArray(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x0600303A RID: 12346 RVA: 0x000AD1CC File Offset: 0x000AB5CC
		public int PikeLength
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600303B RID: 12347 RVA: 0x000AD1FF File Offset: 0x000AB5FF
		public ArraySegment<byte>? GetPikeBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x0600303C RID: 12348 RVA: 0x000AD20E File Offset: 0x000AB60E
		public FlatBufferArray<int> Pike
		{
			get
			{
				if (this.PikeValue == null)
				{
					this.PikeValue = new FlatBufferArray<int>(new Func<int, int>(this.PikeArray), this.PikeLength);
				}
				return this.PikeValue;
			}
		}

		// Token: 0x0600303D RID: 12349 RVA: 0x000AD240 File Offset: 0x000AB640
		public int StickArray(int j)
		{
			int num = this.__p.__offset(50);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x0600303E RID: 12350 RVA: 0x000AD290 File Offset: 0x000AB690
		public int StickLength
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600303F RID: 12351 RVA: 0x000AD2C3 File Offset: 0x000AB6C3
		public ArraySegment<byte>? GetStickBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17000BB0 RID: 2992
		// (get) Token: 0x06003040 RID: 12352 RVA: 0x000AD2D2 File Offset: 0x000AB6D2
		public FlatBufferArray<int> Stick
		{
			get
			{
				if (this.StickValue == null)
				{
					this.StickValue = new FlatBufferArray<int>(new Func<int, int>(this.StickArray), this.StickLength);
				}
				return this.StickValue;
			}
		}

		// Token: 0x06003041 RID: 12353 RVA: 0x000AD304 File Offset: 0x000AB704
		public int BesomArray(int j)
		{
			int num = this.__p.__offset(52);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BB1 RID: 2993
		// (get) Token: 0x06003042 RID: 12354 RVA: 0x000AD354 File Offset: 0x000AB754
		public int BesomLength
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003043 RID: 12355 RVA: 0x000AD387 File Offset: 0x000AB787
		public ArraySegment<byte>? GetBesomBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x06003044 RID: 12356 RVA: 0x000AD396 File Offset: 0x000AB796
		public FlatBufferArray<int> Besom
		{
			get
			{
				if (this.BesomValue == null)
				{
					this.BesomValue = new FlatBufferArray<int>(new Func<int, int>(this.BesomArray), this.BesomLength);
				}
				return this.BesomValue;
			}
		}

		// Token: 0x06003045 RID: 12357 RVA: 0x000AD3C8 File Offset: 0x000AB7C8
		public int GloveArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x06003046 RID: 12358 RVA: 0x000AD418 File Offset: 0x000AB818
		public int GloveLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003047 RID: 12359 RVA: 0x000AD44B File Offset: 0x000AB84B
		public ArraySegment<byte>? GetGloveBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17000BB4 RID: 2996
		// (get) Token: 0x06003048 RID: 12360 RVA: 0x000AD45A File Offset: 0x000AB85A
		public FlatBufferArray<int> Glove
		{
			get
			{
				if (this.GloveValue == null)
				{
					this.GloveValue = new FlatBufferArray<int>(new Func<int, int>(this.GloveArray), this.GloveLength);
				}
				return this.GloveValue;
			}
		}

		// Token: 0x06003049 RID: 12361 RVA: 0x000AD48C File Offset: 0x000AB88C
		public int BikaiArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BB5 RID: 2997
		// (get) Token: 0x0600304A RID: 12362 RVA: 0x000AD4DC File Offset: 0x000AB8DC
		public int BikaiLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600304B RID: 12363 RVA: 0x000AD50F File Offset: 0x000AB90F
		public ArraySegment<byte>? GetBikaiBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17000BB6 RID: 2998
		// (get) Token: 0x0600304C RID: 12364 RVA: 0x000AD51E File Offset: 0x000AB91E
		public FlatBufferArray<int> Bikai
		{
			get
			{
				if (this.BikaiValue == null)
				{
					this.BikaiValue = new FlatBufferArray<int>(new Func<int, int>(this.BikaiArray), this.BikaiLength);
				}
				return this.BikaiValue;
			}
		}

		// Token: 0x0600304D RID: 12365 RVA: 0x000AD550 File Offset: 0x000AB950
		public int ClawArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BB7 RID: 2999
		// (get) Token: 0x0600304E RID: 12366 RVA: 0x000AD5A0 File Offset: 0x000AB9A0
		public int ClawLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600304F RID: 12367 RVA: 0x000AD5D3 File Offset: 0x000AB9D3
		public ArraySegment<byte>? GetClawBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17000BB8 RID: 3000
		// (get) Token: 0x06003050 RID: 12368 RVA: 0x000AD5E2 File Offset: 0x000AB9E2
		public FlatBufferArray<int> Claw
		{
			get
			{
				if (this.ClawValue == null)
				{
					this.ClawValue = new FlatBufferArray<int>(new Func<int, int>(this.ClawArray), this.ClawLength);
				}
				return this.ClawValue;
			}
		}

		// Token: 0x06003051 RID: 12369 RVA: 0x000AD614 File Offset: 0x000ABA14
		public int OfgArray(int j)
		{
			int num = this.__p.__offset(60);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BB9 RID: 3001
		// (get) Token: 0x06003052 RID: 12370 RVA: 0x000AD664 File Offset: 0x000ABA64
		public int OfgLength
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003053 RID: 12371 RVA: 0x000AD697 File Offset: 0x000ABA97
		public ArraySegment<byte>? GetOfgBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x17000BBA RID: 3002
		// (get) Token: 0x06003054 RID: 12372 RVA: 0x000AD6A6 File Offset: 0x000ABAA6
		public FlatBufferArray<int> Ofg
		{
			get
			{
				if (this.OfgValue == null)
				{
					this.OfgValue = new FlatBufferArray<int>(new Func<int, int>(this.OfgArray), this.OfgLength);
				}
				return this.OfgValue;
			}
		}

		// Token: 0x06003055 RID: 12373 RVA: 0x000AD6D8 File Offset: 0x000ABAD8
		public int East_stickArray(int j)
		{
			int num = this.__p.__offset(62);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BBB RID: 3003
		// (get) Token: 0x06003056 RID: 12374 RVA: 0x000AD728 File Offset: 0x000ABB28
		public int East_stickLength
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003057 RID: 12375 RVA: 0x000AD75B File Offset: 0x000ABB5B
		public ArraySegment<byte>? GetEastStickBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x06003058 RID: 12376 RVA: 0x000AD76A File Offset: 0x000ABB6A
		public FlatBufferArray<int> East_stick
		{
			get
			{
				if (this.East_stickValue == null)
				{
					this.East_stickValue = new FlatBufferArray<int>(new Func<int, int>(this.East_stickArray), this.East_stickLength);
				}
				return this.East_stickValue;
			}
		}

		// Token: 0x06003059 RID: 12377 RVA: 0x000AD79C File Offset: 0x000ABB9C
		public int SICKLEArray(int j)
		{
			int num = this.__p.__offset(64);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x0600305A RID: 12378 RVA: 0x000AD7EC File Offset: 0x000ABBEC
		public int SICKLELength
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600305B RID: 12379 RVA: 0x000AD81F File Offset: 0x000ABC1F
		public ArraySegment<byte>? GetSICKLEBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x0600305C RID: 12380 RVA: 0x000AD82E File Offset: 0x000ABC2E
		public FlatBufferArray<int> SICKLE
		{
			get
			{
				if (this.SICKLEValue == null)
				{
					this.SICKLEValue = new FlatBufferArray<int>(new Func<int, int>(this.SICKLEArray), this.SICKLELength);
				}
				return this.SICKLEValue;
			}
		}

		// Token: 0x0600305D RID: 12381 RVA: 0x000AD860 File Offset: 0x000ABC60
		public int TOTEMArray(int j)
		{
			int num = this.__p.__offset(66);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x0600305E RID: 12382 RVA: 0x000AD8B0 File Offset: 0x000ABCB0
		public int TOTEMLength
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600305F RID: 12383 RVA: 0x000AD8E3 File Offset: 0x000ABCE3
		public ArraySegment<byte>? GetTOTEMBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x06003060 RID: 12384 RVA: 0x000AD8F2 File Offset: 0x000ABCF2
		public FlatBufferArray<int> TOTEM
		{
			get
			{
				if (this.TOTEMValue == null)
				{
					this.TOTEMValue = new FlatBufferArray<int>(new Func<int, int>(this.TOTEMArray), this.TOTEMLength);
				}
				return this.TOTEMValue;
			}
		}

		// Token: 0x06003061 RID: 12385 RVA: 0x000AD924 File Offset: 0x000ABD24
		public int AXEArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x06003062 RID: 12386 RVA: 0x000AD974 File Offset: 0x000ABD74
		public int AXELength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003063 RID: 12387 RVA: 0x000AD9A7 File Offset: 0x000ABDA7
		public ArraySegment<byte>? GetAXEBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x06003064 RID: 12388 RVA: 0x000AD9B6 File Offset: 0x000ABDB6
		public FlatBufferArray<int> AXE
		{
			get
			{
				if (this.AXEValue == null)
				{
					this.AXEValue = new FlatBufferArray<int>(new Func<int, int>(this.AXEArray), this.AXELength);
				}
				return this.AXEValue;
			}
		}

		// Token: 0x06003065 RID: 12389 RVA: 0x000AD9E8 File Offset: 0x000ABDE8
		public int BEADSArray(int j)
		{
			int num = this.__p.__offset(70);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x06003066 RID: 12390 RVA: 0x000ADA38 File Offset: 0x000ABE38
		public int BEADSLength
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003067 RID: 12391 RVA: 0x000ADA6B File Offset: 0x000ABE6B
		public ArraySegment<byte>? GetBEADSBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x06003068 RID: 12392 RVA: 0x000ADA7A File Offset: 0x000ABE7A
		public FlatBufferArray<int> BEADS
		{
			get
			{
				if (this.BEADSValue == null)
				{
					this.BEADSValue = new FlatBufferArray<int>(new Func<int, int>(this.BEADSArray), this.BEADSLength);
				}
				return this.BEADSValue;
			}
		}

		// Token: 0x06003069 RID: 12393 RVA: 0x000ADAAC File Offset: 0x000ABEAC
		public int CROSSArray(int j)
		{
			int num = this.__p.__offset(72);
			return (num == 0) ? 0 : (-1342801607 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x0600306A RID: 12394 RVA: 0x000ADAFC File Offset: 0x000ABEFC
		public int CROSSLength
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600306B RID: 12395 RVA: 0x000ADB2F File Offset: 0x000ABF2F
		public ArraySegment<byte>? GetCROSSBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x17000BC6 RID: 3014
		// (get) Token: 0x0600306C RID: 12396 RVA: 0x000ADB3E File Offset: 0x000ABF3E
		public FlatBufferArray<int> CROSS
		{
			get
			{
				if (this.CROSSValue == null)
				{
					this.CROSSValue = new FlatBufferArray<int>(new Func<int, int>(this.CROSSArray), this.CROSSLength);
				}
				return this.CROSSValue;
			}
		}

		// Token: 0x0600306D RID: 12397 RVA: 0x000ADB70 File Offset: 0x000ABF70
		public static Offset<EquipStrModTable> CreateEquipStrModTable(FlatBufferBuilder builder, int ID = 0, VectorOffset WpStrenthModOffset = default(VectorOffset), VectorOffset WpColorQaModOffset = default(VectorOffset), VectorOffset WpColorQbModOffset = default(VectorOffset), VectorOffset ArmStrenthModOffset = default(VectorOffset), VectorOffset ArmColorQaModOffset = default(VectorOffset), VectorOffset ArmColorQbModOffset = default(VectorOffset), VectorOffset JewStrenthModOffset = default(VectorOffset), VectorOffset JewColorQaModOffset = default(VectorOffset), VectorOffset JewColorQbModOffset = default(VectorOffset), VectorOffset HugeSwordOffset = default(VectorOffset), VectorOffset KatanaOffset = default(VectorOffset), VectorOffset ShortSwordOffset = default(VectorOffset), VectorOffset BeamSwordOffset = default(VectorOffset), VectorOffset BluntOffset = default(VectorOffset), VectorOffset RevolverOffset = default(VectorOffset), VectorOffset CrossBowOffset = default(VectorOffset), VectorOffset HandCannonOffset = default(VectorOffset), VectorOffset AutoRifleOffset = default(VectorOffset), VectorOffset AutoPistalOffset = default(VectorOffset), VectorOffset MagicStickOffset = default(VectorOffset), VectorOffset TwigOffset = default(VectorOffset), VectorOffset PikeOffset = default(VectorOffset), VectorOffset StickOffset = default(VectorOffset), VectorOffset BesomOffset = default(VectorOffset), VectorOffset GloveOffset = default(VectorOffset), VectorOffset BikaiOffset = default(VectorOffset), VectorOffset ClawOffset = default(VectorOffset), VectorOffset OfgOffset = default(VectorOffset), VectorOffset East_stickOffset = default(VectorOffset), VectorOffset SICKLEOffset = default(VectorOffset), VectorOffset TOTEMOffset = default(VectorOffset), VectorOffset AXEOffset = default(VectorOffset), VectorOffset BEADSOffset = default(VectorOffset), VectorOffset CROSSOffset = default(VectorOffset))
		{
			builder.StartObject(35);
			EquipStrModTable.AddCROSS(builder, CROSSOffset);
			EquipStrModTable.AddBEADS(builder, BEADSOffset);
			EquipStrModTable.AddAXE(builder, AXEOffset);
			EquipStrModTable.AddTOTEM(builder, TOTEMOffset);
			EquipStrModTable.AddSICKLE(builder, SICKLEOffset);
			EquipStrModTable.AddEastStick(builder, East_stickOffset);
			EquipStrModTable.AddOfg(builder, OfgOffset);
			EquipStrModTable.AddClaw(builder, ClawOffset);
			EquipStrModTable.AddBikai(builder, BikaiOffset);
			EquipStrModTable.AddGlove(builder, GloveOffset);
			EquipStrModTable.AddBesom(builder, BesomOffset);
			EquipStrModTable.AddStick(builder, StickOffset);
			EquipStrModTable.AddPike(builder, PikeOffset);
			EquipStrModTable.AddTwig(builder, TwigOffset);
			EquipStrModTable.AddMagicStick(builder, MagicStickOffset);
			EquipStrModTable.AddAutoPistal(builder, AutoPistalOffset);
			EquipStrModTable.AddAutoRifle(builder, AutoRifleOffset);
			EquipStrModTable.AddHandCannon(builder, HandCannonOffset);
			EquipStrModTable.AddCrossBow(builder, CrossBowOffset);
			EquipStrModTable.AddRevolver(builder, RevolverOffset);
			EquipStrModTable.AddBlunt(builder, BluntOffset);
			EquipStrModTable.AddBeamSword(builder, BeamSwordOffset);
			EquipStrModTable.AddShortSword(builder, ShortSwordOffset);
			EquipStrModTable.AddKatana(builder, KatanaOffset);
			EquipStrModTable.AddHugeSword(builder, HugeSwordOffset);
			EquipStrModTable.AddJewColorQbMod(builder, JewColorQbModOffset);
			EquipStrModTable.AddJewColorQaMod(builder, JewColorQaModOffset);
			EquipStrModTable.AddJewStrenthMod(builder, JewStrenthModOffset);
			EquipStrModTable.AddArmColorQbMod(builder, ArmColorQbModOffset);
			EquipStrModTable.AddArmColorQaMod(builder, ArmColorQaModOffset);
			EquipStrModTable.AddArmStrenthMod(builder, ArmStrenthModOffset);
			EquipStrModTable.AddWpColorQbMod(builder, WpColorQbModOffset);
			EquipStrModTable.AddWpColorQaMod(builder, WpColorQaModOffset);
			EquipStrModTable.AddWpStrenthMod(builder, WpStrenthModOffset);
			EquipStrModTable.AddID(builder, ID);
			return EquipStrModTable.EndEquipStrModTable(builder);
		}

		// Token: 0x0600306E RID: 12398 RVA: 0x000ADCA0 File Offset: 0x000AC0A0
		public static void StartEquipStrModTable(FlatBufferBuilder builder)
		{
			builder.StartObject(35);
		}

		// Token: 0x0600306F RID: 12399 RVA: 0x000ADCAA File Offset: 0x000AC0AA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003070 RID: 12400 RVA: 0x000ADCB5 File Offset: 0x000AC0B5
		public static void AddWpStrenthMod(FlatBufferBuilder builder, VectorOffset WpStrenthModOffset)
		{
			builder.AddOffset(1, WpStrenthModOffset.Value, 0);
		}

		// Token: 0x06003071 RID: 12401 RVA: 0x000ADCC8 File Offset: 0x000AC0C8
		public static VectorOffset CreateWpStrenthModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003072 RID: 12402 RVA: 0x000ADD05 File Offset: 0x000AC105
		public static void StartWpStrenthModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003073 RID: 12403 RVA: 0x000ADD10 File Offset: 0x000AC110
		public static void AddWpColorQaMod(FlatBufferBuilder builder, VectorOffset WpColorQaModOffset)
		{
			builder.AddOffset(2, WpColorQaModOffset.Value, 0);
		}

		// Token: 0x06003074 RID: 12404 RVA: 0x000ADD24 File Offset: 0x000AC124
		public static VectorOffset CreateWpColorQaModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003075 RID: 12405 RVA: 0x000ADD61 File Offset: 0x000AC161
		public static void StartWpColorQaModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003076 RID: 12406 RVA: 0x000ADD6C File Offset: 0x000AC16C
		public static void AddWpColorQbMod(FlatBufferBuilder builder, VectorOffset WpColorQbModOffset)
		{
			builder.AddOffset(3, WpColorQbModOffset.Value, 0);
		}

		// Token: 0x06003077 RID: 12407 RVA: 0x000ADD80 File Offset: 0x000AC180
		public static VectorOffset CreateWpColorQbModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003078 RID: 12408 RVA: 0x000ADDBD File Offset: 0x000AC1BD
		public static void StartWpColorQbModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003079 RID: 12409 RVA: 0x000ADDC8 File Offset: 0x000AC1C8
		public static void AddArmStrenthMod(FlatBufferBuilder builder, VectorOffset ArmStrenthModOffset)
		{
			builder.AddOffset(4, ArmStrenthModOffset.Value, 0);
		}

		// Token: 0x0600307A RID: 12410 RVA: 0x000ADDDC File Offset: 0x000AC1DC
		public static VectorOffset CreateArmStrenthModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600307B RID: 12411 RVA: 0x000ADE19 File Offset: 0x000AC219
		public static void StartArmStrenthModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600307C RID: 12412 RVA: 0x000ADE24 File Offset: 0x000AC224
		public static void AddArmColorQaMod(FlatBufferBuilder builder, VectorOffset ArmColorQaModOffset)
		{
			builder.AddOffset(5, ArmColorQaModOffset.Value, 0);
		}

		// Token: 0x0600307D RID: 12413 RVA: 0x000ADE38 File Offset: 0x000AC238
		public static VectorOffset CreateArmColorQaModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600307E RID: 12414 RVA: 0x000ADE75 File Offset: 0x000AC275
		public static void StartArmColorQaModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600307F RID: 12415 RVA: 0x000ADE80 File Offset: 0x000AC280
		public static void AddArmColorQbMod(FlatBufferBuilder builder, VectorOffset ArmColorQbModOffset)
		{
			builder.AddOffset(6, ArmColorQbModOffset.Value, 0);
		}

		// Token: 0x06003080 RID: 12416 RVA: 0x000ADE94 File Offset: 0x000AC294
		public static VectorOffset CreateArmColorQbModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003081 RID: 12417 RVA: 0x000ADED1 File Offset: 0x000AC2D1
		public static void StartArmColorQbModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003082 RID: 12418 RVA: 0x000ADEDC File Offset: 0x000AC2DC
		public static void AddJewStrenthMod(FlatBufferBuilder builder, VectorOffset JewStrenthModOffset)
		{
			builder.AddOffset(7, JewStrenthModOffset.Value, 0);
		}

		// Token: 0x06003083 RID: 12419 RVA: 0x000ADEF0 File Offset: 0x000AC2F0
		public static VectorOffset CreateJewStrenthModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003084 RID: 12420 RVA: 0x000ADF2D File Offset: 0x000AC32D
		public static void StartJewStrenthModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003085 RID: 12421 RVA: 0x000ADF38 File Offset: 0x000AC338
		public static void AddJewColorQaMod(FlatBufferBuilder builder, VectorOffset JewColorQaModOffset)
		{
			builder.AddOffset(8, JewColorQaModOffset.Value, 0);
		}

		// Token: 0x06003086 RID: 12422 RVA: 0x000ADF4C File Offset: 0x000AC34C
		public static VectorOffset CreateJewColorQaModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003087 RID: 12423 RVA: 0x000ADF89 File Offset: 0x000AC389
		public static void StartJewColorQaModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003088 RID: 12424 RVA: 0x000ADF94 File Offset: 0x000AC394
		public static void AddJewColorQbMod(FlatBufferBuilder builder, VectorOffset JewColorQbModOffset)
		{
			builder.AddOffset(9, JewColorQbModOffset.Value, 0);
		}

		// Token: 0x06003089 RID: 12425 RVA: 0x000ADFA8 File Offset: 0x000AC3A8
		public static VectorOffset CreateJewColorQbModVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600308A RID: 12426 RVA: 0x000ADFE5 File Offset: 0x000AC3E5
		public static void StartJewColorQbModVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600308B RID: 12427 RVA: 0x000ADFF0 File Offset: 0x000AC3F0
		public static void AddHugeSword(FlatBufferBuilder builder, VectorOffset HugeSwordOffset)
		{
			builder.AddOffset(10, HugeSwordOffset.Value, 0);
		}

		// Token: 0x0600308C RID: 12428 RVA: 0x000AE004 File Offset: 0x000AC404
		public static VectorOffset CreateHugeSwordVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600308D RID: 12429 RVA: 0x000AE041 File Offset: 0x000AC441
		public static void StartHugeSwordVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600308E RID: 12430 RVA: 0x000AE04C File Offset: 0x000AC44C
		public static void AddKatana(FlatBufferBuilder builder, VectorOffset KatanaOffset)
		{
			builder.AddOffset(11, KatanaOffset.Value, 0);
		}

		// Token: 0x0600308F RID: 12431 RVA: 0x000AE060 File Offset: 0x000AC460
		public static VectorOffset CreateKatanaVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003090 RID: 12432 RVA: 0x000AE09D File Offset: 0x000AC49D
		public static void StartKatanaVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003091 RID: 12433 RVA: 0x000AE0A8 File Offset: 0x000AC4A8
		public static void AddShortSword(FlatBufferBuilder builder, VectorOffset ShortSwordOffset)
		{
			builder.AddOffset(12, ShortSwordOffset.Value, 0);
		}

		// Token: 0x06003092 RID: 12434 RVA: 0x000AE0BC File Offset: 0x000AC4BC
		public static VectorOffset CreateShortSwordVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003093 RID: 12435 RVA: 0x000AE0F9 File Offset: 0x000AC4F9
		public static void StartShortSwordVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003094 RID: 12436 RVA: 0x000AE104 File Offset: 0x000AC504
		public static void AddBeamSword(FlatBufferBuilder builder, VectorOffset BeamSwordOffset)
		{
			builder.AddOffset(13, BeamSwordOffset.Value, 0);
		}

		// Token: 0x06003095 RID: 12437 RVA: 0x000AE118 File Offset: 0x000AC518
		public static VectorOffset CreateBeamSwordVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003096 RID: 12438 RVA: 0x000AE155 File Offset: 0x000AC555
		public static void StartBeamSwordVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003097 RID: 12439 RVA: 0x000AE160 File Offset: 0x000AC560
		public static void AddBlunt(FlatBufferBuilder builder, VectorOffset BluntOffset)
		{
			builder.AddOffset(14, BluntOffset.Value, 0);
		}

		// Token: 0x06003098 RID: 12440 RVA: 0x000AE174 File Offset: 0x000AC574
		public static VectorOffset CreateBluntVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x000AE1B1 File Offset: 0x000AC5B1
		public static void StartBluntVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x000AE1BC File Offset: 0x000AC5BC
		public static void AddRevolver(FlatBufferBuilder builder, VectorOffset RevolverOffset)
		{
			builder.AddOffset(15, RevolverOffset.Value, 0);
		}

		// Token: 0x0600309B RID: 12443 RVA: 0x000AE1D0 File Offset: 0x000AC5D0
		public static VectorOffset CreateRevolverVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600309C RID: 12444 RVA: 0x000AE20D File Offset: 0x000AC60D
		public static void StartRevolverVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600309D RID: 12445 RVA: 0x000AE218 File Offset: 0x000AC618
		public static void AddCrossBow(FlatBufferBuilder builder, VectorOffset CrossBowOffset)
		{
			builder.AddOffset(16, CrossBowOffset.Value, 0);
		}

		// Token: 0x0600309E RID: 12446 RVA: 0x000AE22C File Offset: 0x000AC62C
		public static VectorOffset CreateCrossBowVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600309F RID: 12447 RVA: 0x000AE269 File Offset: 0x000AC669
		public static void StartCrossBowVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x000AE274 File Offset: 0x000AC674
		public static void AddHandCannon(FlatBufferBuilder builder, VectorOffset HandCannonOffset)
		{
			builder.AddOffset(17, HandCannonOffset.Value, 0);
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x000AE288 File Offset: 0x000AC688
		public static VectorOffset CreateHandCannonVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030A2 RID: 12450 RVA: 0x000AE2C5 File Offset: 0x000AC6C5
		public static void StartHandCannonVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030A3 RID: 12451 RVA: 0x000AE2D0 File Offset: 0x000AC6D0
		public static void AddAutoRifle(FlatBufferBuilder builder, VectorOffset AutoRifleOffset)
		{
			builder.AddOffset(18, AutoRifleOffset.Value, 0);
		}

		// Token: 0x060030A4 RID: 12452 RVA: 0x000AE2E4 File Offset: 0x000AC6E4
		public static VectorOffset CreateAutoRifleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030A5 RID: 12453 RVA: 0x000AE321 File Offset: 0x000AC721
		public static void StartAutoRifleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030A6 RID: 12454 RVA: 0x000AE32C File Offset: 0x000AC72C
		public static void AddAutoPistal(FlatBufferBuilder builder, VectorOffset AutoPistalOffset)
		{
			builder.AddOffset(19, AutoPistalOffset.Value, 0);
		}

		// Token: 0x060030A7 RID: 12455 RVA: 0x000AE340 File Offset: 0x000AC740
		public static VectorOffset CreateAutoPistalVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030A8 RID: 12456 RVA: 0x000AE37D File Offset: 0x000AC77D
		public static void StartAutoPistalVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030A9 RID: 12457 RVA: 0x000AE388 File Offset: 0x000AC788
		public static void AddMagicStick(FlatBufferBuilder builder, VectorOffset MagicStickOffset)
		{
			builder.AddOffset(20, MagicStickOffset.Value, 0);
		}

		// Token: 0x060030AA RID: 12458 RVA: 0x000AE39C File Offset: 0x000AC79C
		public static VectorOffset CreateMagicStickVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030AB RID: 12459 RVA: 0x000AE3D9 File Offset: 0x000AC7D9
		public static void StartMagicStickVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030AC RID: 12460 RVA: 0x000AE3E4 File Offset: 0x000AC7E4
		public static void AddTwig(FlatBufferBuilder builder, VectorOffset TwigOffset)
		{
			builder.AddOffset(21, TwigOffset.Value, 0);
		}

		// Token: 0x060030AD RID: 12461 RVA: 0x000AE3F8 File Offset: 0x000AC7F8
		public static VectorOffset CreateTwigVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030AE RID: 12462 RVA: 0x000AE435 File Offset: 0x000AC835
		public static void StartTwigVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030AF RID: 12463 RVA: 0x000AE440 File Offset: 0x000AC840
		public static void AddPike(FlatBufferBuilder builder, VectorOffset PikeOffset)
		{
			builder.AddOffset(22, PikeOffset.Value, 0);
		}

		// Token: 0x060030B0 RID: 12464 RVA: 0x000AE454 File Offset: 0x000AC854
		public static VectorOffset CreatePikeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030B1 RID: 12465 RVA: 0x000AE491 File Offset: 0x000AC891
		public static void StartPikeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030B2 RID: 12466 RVA: 0x000AE49C File Offset: 0x000AC89C
		public static void AddStick(FlatBufferBuilder builder, VectorOffset StickOffset)
		{
			builder.AddOffset(23, StickOffset.Value, 0);
		}

		// Token: 0x060030B3 RID: 12467 RVA: 0x000AE4B0 File Offset: 0x000AC8B0
		public static VectorOffset CreateStickVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030B4 RID: 12468 RVA: 0x000AE4ED File Offset: 0x000AC8ED
		public static void StartStickVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030B5 RID: 12469 RVA: 0x000AE4F8 File Offset: 0x000AC8F8
		public static void AddBesom(FlatBufferBuilder builder, VectorOffset BesomOffset)
		{
			builder.AddOffset(24, BesomOffset.Value, 0);
		}

		// Token: 0x060030B6 RID: 12470 RVA: 0x000AE50C File Offset: 0x000AC90C
		public static VectorOffset CreateBesomVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030B7 RID: 12471 RVA: 0x000AE549 File Offset: 0x000AC949
		public static void StartBesomVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030B8 RID: 12472 RVA: 0x000AE554 File Offset: 0x000AC954
		public static void AddGlove(FlatBufferBuilder builder, VectorOffset GloveOffset)
		{
			builder.AddOffset(25, GloveOffset.Value, 0);
		}

		// Token: 0x060030B9 RID: 12473 RVA: 0x000AE568 File Offset: 0x000AC968
		public static VectorOffset CreateGloveVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030BA RID: 12474 RVA: 0x000AE5A5 File Offset: 0x000AC9A5
		public static void StartGloveVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030BB RID: 12475 RVA: 0x000AE5B0 File Offset: 0x000AC9B0
		public static void AddBikai(FlatBufferBuilder builder, VectorOffset BikaiOffset)
		{
			builder.AddOffset(26, BikaiOffset.Value, 0);
		}

		// Token: 0x060030BC RID: 12476 RVA: 0x000AE5C4 File Offset: 0x000AC9C4
		public static VectorOffset CreateBikaiVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x000AE601 File Offset: 0x000ACA01
		public static void StartBikaiVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030BE RID: 12478 RVA: 0x000AE60C File Offset: 0x000ACA0C
		public static void AddClaw(FlatBufferBuilder builder, VectorOffset ClawOffset)
		{
			builder.AddOffset(27, ClawOffset.Value, 0);
		}

		// Token: 0x060030BF RID: 12479 RVA: 0x000AE620 File Offset: 0x000ACA20
		public static VectorOffset CreateClawVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030C0 RID: 12480 RVA: 0x000AE65D File Offset: 0x000ACA5D
		public static void StartClawVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030C1 RID: 12481 RVA: 0x000AE668 File Offset: 0x000ACA68
		public static void AddOfg(FlatBufferBuilder builder, VectorOffset OfgOffset)
		{
			builder.AddOffset(28, OfgOffset.Value, 0);
		}

		// Token: 0x060030C2 RID: 12482 RVA: 0x000AE67C File Offset: 0x000ACA7C
		public static VectorOffset CreateOfgVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030C3 RID: 12483 RVA: 0x000AE6B9 File Offset: 0x000ACAB9
		public static void StartOfgVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030C4 RID: 12484 RVA: 0x000AE6C4 File Offset: 0x000ACAC4
		public static void AddEastStick(FlatBufferBuilder builder, VectorOffset EastStickOffset)
		{
			builder.AddOffset(29, EastStickOffset.Value, 0);
		}

		// Token: 0x060030C5 RID: 12485 RVA: 0x000AE6D8 File Offset: 0x000ACAD8
		public static VectorOffset CreateEastStickVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030C6 RID: 12486 RVA: 0x000AE715 File Offset: 0x000ACB15
		public static void StartEastStickVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030C7 RID: 12487 RVA: 0x000AE720 File Offset: 0x000ACB20
		public static void AddSICKLE(FlatBufferBuilder builder, VectorOffset SICKLEOffset)
		{
			builder.AddOffset(30, SICKLEOffset.Value, 0);
		}

		// Token: 0x060030C8 RID: 12488 RVA: 0x000AE734 File Offset: 0x000ACB34
		public static VectorOffset CreateSICKLEVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030C9 RID: 12489 RVA: 0x000AE771 File Offset: 0x000ACB71
		public static void StartSICKLEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030CA RID: 12490 RVA: 0x000AE77C File Offset: 0x000ACB7C
		public static void AddTOTEM(FlatBufferBuilder builder, VectorOffset TOTEMOffset)
		{
			builder.AddOffset(31, TOTEMOffset.Value, 0);
		}

		// Token: 0x060030CB RID: 12491 RVA: 0x000AE790 File Offset: 0x000ACB90
		public static VectorOffset CreateTOTEMVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030CC RID: 12492 RVA: 0x000AE7CD File Offset: 0x000ACBCD
		public static void StartTOTEMVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030CD RID: 12493 RVA: 0x000AE7D8 File Offset: 0x000ACBD8
		public static void AddAXE(FlatBufferBuilder builder, VectorOffset AXEOffset)
		{
			builder.AddOffset(32, AXEOffset.Value, 0);
		}

		// Token: 0x060030CE RID: 12494 RVA: 0x000AE7EC File Offset: 0x000ACBEC
		public static VectorOffset CreateAXEVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030CF RID: 12495 RVA: 0x000AE829 File Offset: 0x000ACC29
		public static void StartAXEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030D0 RID: 12496 RVA: 0x000AE834 File Offset: 0x000ACC34
		public static void AddBEADS(FlatBufferBuilder builder, VectorOffset BEADSOffset)
		{
			builder.AddOffset(33, BEADSOffset.Value, 0);
		}

		// Token: 0x060030D1 RID: 12497 RVA: 0x000AE848 File Offset: 0x000ACC48
		public static VectorOffset CreateBEADSVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030D2 RID: 12498 RVA: 0x000AE885 File Offset: 0x000ACC85
		public static void StartBEADSVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030D3 RID: 12499 RVA: 0x000AE890 File Offset: 0x000ACC90
		public static void AddCROSS(FlatBufferBuilder builder, VectorOffset CROSSOffset)
		{
			builder.AddOffset(34, CROSSOffset.Value, 0);
		}

		// Token: 0x060030D4 RID: 12500 RVA: 0x000AE8A4 File Offset: 0x000ACCA4
		public static VectorOffset CreateCROSSVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030D5 RID: 12501 RVA: 0x000AE8E1 File Offset: 0x000ACCE1
		public static void StartCROSSVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030D6 RID: 12502 RVA: 0x000AE8EC File Offset: 0x000ACCEC
		public static Offset<EquipStrModTable> EndEquipStrModTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrModTable>(value);
		}

		// Token: 0x060030D7 RID: 12503 RVA: 0x000AE906 File Offset: 0x000ACD06
		public static void FinishEquipStrModTableBuffer(FlatBufferBuilder builder, Offset<EquipStrModTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001426 RID: 5158
		private Table __p = new Table();

		// Token: 0x04001427 RID: 5159
		private FlatBufferArray<int> WpStrenthModValue;

		// Token: 0x04001428 RID: 5160
		private FlatBufferArray<int> WpColorQaModValue;

		// Token: 0x04001429 RID: 5161
		private FlatBufferArray<int> WpColorQbModValue;

		// Token: 0x0400142A RID: 5162
		private FlatBufferArray<int> ArmStrenthModValue;

		// Token: 0x0400142B RID: 5163
		private FlatBufferArray<int> ArmColorQaModValue;

		// Token: 0x0400142C RID: 5164
		private FlatBufferArray<int> ArmColorQbModValue;

		// Token: 0x0400142D RID: 5165
		private FlatBufferArray<int> JewStrenthModValue;

		// Token: 0x0400142E RID: 5166
		private FlatBufferArray<int> JewColorQaModValue;

		// Token: 0x0400142F RID: 5167
		private FlatBufferArray<int> JewColorQbModValue;

		// Token: 0x04001430 RID: 5168
		private FlatBufferArray<int> HugeSwordValue;

		// Token: 0x04001431 RID: 5169
		private FlatBufferArray<int> KatanaValue;

		// Token: 0x04001432 RID: 5170
		private FlatBufferArray<int> ShortSwordValue;

		// Token: 0x04001433 RID: 5171
		private FlatBufferArray<int> BeamSwordValue;

		// Token: 0x04001434 RID: 5172
		private FlatBufferArray<int> BluntValue;

		// Token: 0x04001435 RID: 5173
		private FlatBufferArray<int> RevolverValue;

		// Token: 0x04001436 RID: 5174
		private FlatBufferArray<int> CrossBowValue;

		// Token: 0x04001437 RID: 5175
		private FlatBufferArray<int> HandCannonValue;

		// Token: 0x04001438 RID: 5176
		private FlatBufferArray<int> AutoRifleValue;

		// Token: 0x04001439 RID: 5177
		private FlatBufferArray<int> AutoPistalValue;

		// Token: 0x0400143A RID: 5178
		private FlatBufferArray<int> MagicStickValue;

		// Token: 0x0400143B RID: 5179
		private FlatBufferArray<int> TwigValue;

		// Token: 0x0400143C RID: 5180
		private FlatBufferArray<int> PikeValue;

		// Token: 0x0400143D RID: 5181
		private FlatBufferArray<int> StickValue;

		// Token: 0x0400143E RID: 5182
		private FlatBufferArray<int> BesomValue;

		// Token: 0x0400143F RID: 5183
		private FlatBufferArray<int> GloveValue;

		// Token: 0x04001440 RID: 5184
		private FlatBufferArray<int> BikaiValue;

		// Token: 0x04001441 RID: 5185
		private FlatBufferArray<int> ClawValue;

		// Token: 0x04001442 RID: 5186
		private FlatBufferArray<int> OfgValue;

		// Token: 0x04001443 RID: 5187
		private FlatBufferArray<int> East_stickValue;

		// Token: 0x04001444 RID: 5188
		private FlatBufferArray<int> SICKLEValue;

		// Token: 0x04001445 RID: 5189
		private FlatBufferArray<int> TOTEMValue;

		// Token: 0x04001446 RID: 5190
		private FlatBufferArray<int> AXEValue;

		// Token: 0x04001447 RID: 5191
		private FlatBufferArray<int> BEADSValue;

		// Token: 0x04001448 RID: 5192
		private FlatBufferArray<int> CROSSValue;

		// Token: 0x0200040D RID: 1037
		public enum eCrypt
		{
			// Token: 0x0400144A RID: 5194
			code = -1342801607
		}
	}
}
