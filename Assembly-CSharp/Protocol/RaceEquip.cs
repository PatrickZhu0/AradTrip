using System;

namespace Protocol
{
	// Token: 0x020009F3 RID: 2547
	public class RaceEquip : IProtocolStream
	{
		// Token: 0x0600716E RID: 29038 RVA: 0x0014716C File Offset: 0x0014556C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phyAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phydef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magdef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strenth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamina);
			BaseDLL.encode_uint32(buffer, ref pos_, this.intellect);
			BaseDLL.encode_uint32(buffer, ref pos_, this.spirit);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.properties.Length);
			for (int i = 0; i < this.properties.Length; i++)
			{
				this.properties[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCard);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disphyAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disMagAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disphydef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dismagdef);
			BaseDLL.encode_int8(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fashionAttrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phyDefPercent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magDefPercent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTimeLimit);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.atkPropEx.Length);
			for (int j = 0; j < this.atkPropEx.Length; j++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.atkPropEx[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.strPropEx.Length);
			for (int k = 0; k < this.strPropEx.Length; k++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.strPropEx[k]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.defPropEx.Length);
			for (int l = 0; l < this.defPropEx.Length; l++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.defPropEx[l]);
			}
			BaseDLL.encode_int32(buffer, ref pos_, this.abnormalResistsTotal);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.abnormalResists.Length);
			for (int m = 0; m < this.abnormalResists.Length; m++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.abnormalResists[m]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mountPrecBeads.Length);
			for (int n = 0; n < this.mountPrecBeads.Length; n++)
			{
				this.mountPrecBeads[n].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.magicCardLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inscriptionIds.Length);
			for (int num = 0; num < this.inscriptionIds.Length; num++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionIds[num]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.independAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.indpendAtkStreng);
		}

		// Token: 0x0600716F RID: 29039 RVA: 0x001474B4 File Offset: 0x001458B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phyAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phydef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magdef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamina);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.intellect);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.spirit);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.properties = new RaceItemRandProperty[(int)num];
			for (int i = 0; i < this.properties.Length; i++)
			{
				this.properties[i] = new RaceItemRandProperty();
				this.properties[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCard);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disphyAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disMagAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disphydef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dismagdef);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fashionAttrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phyDefPercent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magDefPercent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTimeLimit);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.atkPropEx = new int[(int)num2];
			for (int j = 0; j < this.atkPropEx.Length; j++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.atkPropEx[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.strPropEx = new int[(int)num3];
			for (int k = 0; k < this.strPropEx.Length; k++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.strPropEx[k]);
			}
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.defPropEx = new int[(int)num4];
			for (int l = 0; l < this.defPropEx.Length; l++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.defPropEx[l]);
			}
			BaseDLL.decode_int32(buffer, ref pos_, ref this.abnormalResistsTotal);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.abnormalResists = new int[(int)num5];
			for (int m = 0; m < this.abnormalResists.Length; m++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.abnormalResists[m]);
			}
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.mountPrecBeads = new RacePrecBead[(int)num6];
			for (int n = 0; n < this.mountPrecBeads.Length; n++)
			{
				this.mountPrecBeads[n] = new RacePrecBead();
				this.mountPrecBeads[n].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.magicCardLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.inscriptionIds = new uint[(int)num7];
			for (int num8 = 0; num8 < this.inscriptionIds.Length; num8++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionIds[num8]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.independAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.indpendAtkStreng);
		}

		// Token: 0x06007170 RID: 29040 RVA: 0x00147870 File Offset: 0x00145C70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phyAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phydef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magdef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strenth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamina);
			BaseDLL.encode_uint32(buffer, ref pos_, this.intellect);
			BaseDLL.encode_uint32(buffer, ref pos_, this.spirit);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.properties.Length);
			for (int i = 0; i < this.properties.Length; i++)
			{
				this.properties[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCard);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disphyAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disMagAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.disphydef);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dismagdef);
			BaseDLL.encode_int8(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fashionAttrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phyDefPercent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.magDefPercent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTimeLimit);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.atkPropEx.Length);
			for (int j = 0; j < this.atkPropEx.Length; j++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.atkPropEx[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.strPropEx.Length);
			for (int k = 0; k < this.strPropEx.Length; k++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.strPropEx[k]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.defPropEx.Length);
			for (int l = 0; l < this.defPropEx.Length; l++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.defPropEx[l]);
			}
			BaseDLL.encode_int32(buffer, ref pos_, this.abnormalResistsTotal);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.abnormalResists.Length);
			for (int m = 0; m < this.abnormalResists.Length; m++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.abnormalResists[m]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mountPrecBeads.Length);
			for (int n = 0; n < this.mountPrecBeads.Length; n++)
			{
				this.mountPrecBeads[n].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.magicCardLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inscriptionIds.Length);
			for (int num = 0; num < this.inscriptionIds.Length; num++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionIds[num]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.independAtk);
			BaseDLL.encode_uint32(buffer, ref pos_, this.indpendAtkStreng);
		}

		// Token: 0x06007171 RID: 29041 RVA: 0x00147BB8 File Offset: 0x00145FB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phyAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phydef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magdef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamina);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.intellect);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.spirit);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.properties = new RaceItemRandProperty[(int)num];
			for (int i = 0; i < this.properties.Length; i++)
			{
				this.properties[i] = new RaceItemRandProperty();
				this.properties[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCard);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disphyAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disMagAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.disphydef);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dismagdef);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fashionAttrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phyDefPercent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magDefPercent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTimeLimit);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.atkPropEx = new int[(int)num2];
			for (int j = 0; j < this.atkPropEx.Length; j++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.atkPropEx[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.strPropEx = new int[(int)num3];
			for (int k = 0; k < this.strPropEx.Length; k++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.strPropEx[k]);
			}
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.defPropEx = new int[(int)num4];
			for (int l = 0; l < this.defPropEx.Length; l++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.defPropEx[l]);
			}
			BaseDLL.decode_int32(buffer, ref pos_, ref this.abnormalResistsTotal);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.abnormalResists = new int[(int)num5];
			for (int m = 0; m < this.abnormalResists.Length; m++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.abnormalResists[m]);
			}
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.mountPrecBeads = new RacePrecBead[(int)num6];
			for (int n = 0; n < this.mountPrecBeads.Length; n++)
			{
				this.mountPrecBeads[n] = new RacePrecBead();
				this.mountPrecBeads[n].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.magicCardLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.inscriptionIds = new uint[(int)num7];
			for (int num8 = 0; num8 < this.inscriptionIds.Length; num8++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionIds[num8]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.independAtk);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.indpendAtkStreng);
		}

		// Token: 0x06007172 RID: 29042 RVA: 0x00147F74 File Offset: 0x00146374
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.properties.Length; i++)
			{
				num += this.properties[i].getLen();
			}
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 2 + 4 * this.atkPropEx.Length;
			num += 2 + 4 * this.strPropEx.Length;
			num += 2 + 4 * this.defPropEx.Length;
			num += 4;
			num += 2 + 4 * this.abnormalResists.Length;
			num += 2;
			for (int j = 0; j < this.mountPrecBeads.Length; j++)
			{
				num += this.mountPrecBeads[j].getLen();
			}
			num++;
			num++;
			num++;
			num += 4;
			num += 2 + 4 * this.inscriptionIds.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x040033D1 RID: 13265
		public ulong uid;

		// Token: 0x040033D2 RID: 13266
		public uint id;

		// Token: 0x040033D3 RID: 13267
		public uint pos;

		// Token: 0x040033D4 RID: 13268
		public uint phyAtk;

		// Token: 0x040033D5 RID: 13269
		public uint magAtk;

		// Token: 0x040033D6 RID: 13270
		public uint phydef;

		// Token: 0x040033D7 RID: 13271
		public uint magdef;

		// Token: 0x040033D8 RID: 13272
		public uint strenth;

		// Token: 0x040033D9 RID: 13273
		public uint stamina;

		// Token: 0x040033DA RID: 13274
		public uint intellect;

		// Token: 0x040033DB RID: 13275
		public uint spirit;

		// Token: 0x040033DC RID: 13276
		public RaceItemRandProperty[] properties = new RaceItemRandProperty[0];

		// Token: 0x040033DD RID: 13277
		public uint magicCard;

		// Token: 0x040033DE RID: 13278
		public uint disphyAtk;

		// Token: 0x040033DF RID: 13279
		public uint disMagAtk;

		// Token: 0x040033E0 RID: 13280
		public uint disphydef;

		// Token: 0x040033E1 RID: 13281
		public uint dismagdef;

		// Token: 0x040033E2 RID: 13282
		public byte strengthen;

		// Token: 0x040033E3 RID: 13283
		public uint fashionAttrId;

		// Token: 0x040033E4 RID: 13284
		public uint phyDefPercent;

		// Token: 0x040033E5 RID: 13285
		public uint magDefPercent;

		// Token: 0x040033E6 RID: 13286
		public uint preciousBeadId;

		// Token: 0x040033E7 RID: 13287
		public byte isTimeLimit;

		// Token: 0x040033E8 RID: 13288
		public int[] atkPropEx = new int[0];

		// Token: 0x040033E9 RID: 13289
		public int[] strPropEx = new int[0];

		// Token: 0x040033EA RID: 13290
		public int[] defPropEx = new int[0];

		// Token: 0x040033EB RID: 13291
		public int abnormalResistsTotal;

		// Token: 0x040033EC RID: 13292
		public int[] abnormalResists = new int[0];

		// Token: 0x040033ED RID: 13293
		public RacePrecBead[] mountPrecBeads = new RacePrecBead[0];

		// Token: 0x040033EE RID: 13294
		public byte magicCardLv;

		// Token: 0x040033EF RID: 13295
		public byte equipType;

		// Token: 0x040033F0 RID: 13296
		public byte enhanceType;

		// Token: 0x040033F1 RID: 13297
		public uint enhanceNum;

		// Token: 0x040033F2 RID: 13298
		public uint[] inscriptionIds = new uint[0];

		// Token: 0x040033F3 RID: 13299
		public uint independAtk;

		// Token: 0x040033F4 RID: 13300
		public uint indpendAtkStreng;
	}
}
