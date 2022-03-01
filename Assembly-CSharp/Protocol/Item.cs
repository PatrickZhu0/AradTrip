using System;
using System.Reflection;

namespace Protocol
{
	// Token: 0x02000631 RID: 1585
	public class Item : StreamObject
	{
		// Token: 0x06005595 RID: 21909 RVA: 0x00105994 File Offset: 0x00103D94
		public override bool GetStructProperty(FieldInfo field, byte[] buffer, ref int pos, int length)
		{
			if (field.FieldType == typeof(ItemRandProp[]))
			{
				byte b = 0;
				BaseDLL.decode_int8(buffer, ref pos, ref b);
				for (int i = 0; i < (int)b; i++)
				{
					ItemRandProp itemRandProp = new ItemRandProp();
					itemRandProp.decode(buffer, ref pos);
					this.randProps[i] = itemRandProp;
				}
				return true;
			}
			if (field.FieldType == typeof(GemStone[]))
			{
				byte b2 = 0;
				BaseDLL.decode_int8(buffer, ref pos, ref b2);
				return true;
			}
			if (field.FieldType == typeof(ItemMagicProperty[]))
			{
				return true;
			}
			if (field.FieldType == typeof(ItemMountedMagic))
			{
				ItemMountedMagic itemMountedMagic = new ItemMountedMagic();
				itemMountedMagic.decode(buffer, ref pos);
				this.mountedMagic = itemMountedMagic;
				return true;
			}
			if (field.FieldType == typeof(PreciousBeadMountHole[]))
			{
				byte b3 = 0;
				BaseDLL.decode_int8(buffer, ref pos, ref b3);
				for (int j = 0; j < (int)b3; j++)
				{
					PreciousBeadMountHole preciousBeadMountHole = new PreciousBeadMountHole();
					preciousBeadMountHole.decode(buffer, ref pos);
					this.preciousBeadHoles[j] = preciousBeadMountHole;
				}
				return true;
			}
			if (field.FieldType == typeof(InscriptionMountHole[]))
			{
				short num = 0;
				BaseDLL.decode_int16(buffer, ref pos, ref num);
				if (num > (short)Item.MAX_INSCRIPTION_MOUNTHOLE_NUM)
				{
					num = (short)Item.MAX_INSCRIPTION_MOUNTHOLE_NUM;
				}
				this.inscriptionHoles = new InscriptionMountHole[(int)num];
				for (int k = 0; k < (int)num; k++)
				{
					InscriptionMountHole inscriptionMountHole = new InscriptionMountHole();
					inscriptionMountHole.decode(buffer, ref pos);
					this.inscriptionHoles[k] = inscriptionMountHole;
				}
				return true;
			}
			return false;
		}

		// Token: 0x04001F28 RID: 7976
		public static byte MAX_EQUIPATTR_NUM = 3;

		// Token: 0x04001F29 RID: 7977
		public static byte MAX_EQUIP_GEM_HOLE = 4;

		// Token: 0x04001F2A RID: 7978
		public static byte MAX_MAGICPROP_NUM = 5;

		// Token: 0x04001F2B RID: 7979
		public static byte MAX_PRECBEAD_MOUNTHOLE_NUM = 2;

		// Token: 0x04001F2C RID: 7980
		public static byte MAX_INSCRIPTION_MOUNTHOLE_NUM = 2;

		// Token: 0x04001F2D RID: 7981
		public ulong uid;

		// Token: 0x04001F2E RID: 7982
		public uint dataid;

		// Token: 0x04001F2F RID: 7983
		[SProperty(1)]
		public ushort num;

		// Token: 0x04001F30 RID: 7984
		[SProperty(2)]
		public byte bind;

		// Token: 0x04001F31 RID: 7985
		[SProperty(3)]
		public byte pack;

		// Token: 0x04001F32 RID: 7986
		[SProperty(4)]
		public uint grid;

		// Token: 0x04001F33 RID: 7987
		[SProperty(5)]
		public uint phyatk;

		// Token: 0x04001F34 RID: 7988
		[SProperty(6)]
		public uint magatk;

		// Token: 0x04001F35 RID: 7989
		[SProperty(7)]
		public uint phydef;

		// Token: 0x04001F36 RID: 7990
		[SProperty(8)]
		public uint magdef;

		// Token: 0x04001F37 RID: 7991
		[SProperty(9)]
		public uint strenth;

		// Token: 0x04001F38 RID: 7992
		[SProperty(10)]
		public uint stamina;

		// Token: 0x04001F39 RID: 7993
		[SProperty(11)]
		public uint intellect;

		// Token: 0x04001F3A RID: 7994
		[SProperty(12)]
		public uint spirit;

		// Token: 0x04001F3B RID: 7995
		[SProperty(13)]
		public byte qualitylv;

		// Token: 0x04001F3C RID: 7996
		[SProperty(14)]
		public byte quality;

		// Token: 0x04001F3D RID: 7997
		[SProperty(15)]
		public byte strengthen;

		// Token: 0x04001F3E RID: 7998
		[SProperty(16)]
		public ItemRandProp[] randProps = new ItemRandProp[(int)Item.MAX_EQUIPATTR_NUM];

		// Token: 0x04001F3F RID: 7999
		[SProperty(17)]
		public uint dayUseNum;

		// Token: 0x04001F40 RID: 8000
		[SProperty(19)]
		public uint param1;

		// Token: 0x04001F41 RID: 8001
		[SProperty(20)]
		public uint param2;

		// Token: 0x04001F42 RID: 8002
		[SProperty(22)]
		public uint deadLine;

		// Token: 0x04001F43 RID: 8003
		[SProperty(24)]
		public uint strFailedTimes;

		// Token: 0x04001F44 RID: 8004
		[SProperty(18)]
		public ItemMountedMagic mountedMagic;

		// Token: 0x04001F45 RID: 8005
		[SProperty(25)]
		public byte sealstate;

		// Token: 0x04001F46 RID: 8006
		[SProperty(26)]
		public uint sealcount;

		// Token: 0x04001F47 RID: 8007
		[SProperty(27)]
		public uint disPhyAtk;

		// Token: 0x04001F48 RID: 8008
		[SProperty(28)]
		public uint disMagAtk;

		// Token: 0x04001F49 RID: 8009
		[SProperty(29)]
		public uint disPhyDef;

		// Token: 0x04001F4A RID: 8010
		[SProperty(30)]
		public uint disMagDef;

		// Token: 0x04001F4B RID: 8011
		[SProperty(35)]
		public uint valueScore;

		// Token: 0x04001F4C RID: 8012
		[SProperty(37)]
		public uint fashionAttributeID;

		// Token: 0x04001F4D RID: 8013
		[SProperty(38)]
		public uint fashionFreeSelNum;

		// Token: 0x04001F4E RID: 8014
		[SProperty(39)]
		public uint disPhyDefRate;

		// Token: 0x04001F4F RID: 8015
		[SProperty(40)]
		public uint disMagDefRate;

		// Token: 0x04001F50 RID: 8016
		[SProperty(41)]
		public uint beadCardId;

		// Token: 0x04001F51 RID: 8017
		[SProperty(42)]
		public uint strPropLight;

		// Token: 0x04001F52 RID: 8018
		[SProperty(43)]
		public uint strPropFire;

		// Token: 0x04001F53 RID: 8019
		[SProperty(44)]
		public uint strPropIce;

		// Token: 0x04001F54 RID: 8020
		[SProperty(45)]
		public uint strPropDark;

		// Token: 0x04001F55 RID: 8021
		[SProperty(46)]
		public uint defPropLight;

		// Token: 0x04001F56 RID: 8022
		[SProperty(47)]
		public uint defPropFire;

		// Token: 0x04001F57 RID: 8023
		[SProperty(48)]
		public uint defPropIce;

		// Token: 0x04001F58 RID: 8024
		[SProperty(49)]
		public uint defPropDark;

		// Token: 0x04001F59 RID: 8025
		[SProperty(50)]
		public uint abnormalResistsTotal;

		// Token: 0x04001F5A RID: 8026
		[SProperty(51)]
		public uint abnormalResistFlash;

		// Token: 0x04001F5B RID: 8027
		[SProperty(52)]
		public uint abnormalResistBleeding;

		// Token: 0x04001F5C RID: 8028
		[SProperty(53)]
		public uint abnormalResistBurn;

		// Token: 0x04001F5D RID: 8029
		[SProperty(54)]
		public uint abnormalResistPoison;

		// Token: 0x04001F5E RID: 8030
		[SProperty(55)]
		public uint abnormalResistBlind;

		// Token: 0x04001F5F RID: 8031
		[SProperty(56)]
		public uint abnormalResistStun;

		// Token: 0x04001F60 RID: 8032
		[SProperty(57)]
		public uint abnormalResistStone;

		// Token: 0x04001F61 RID: 8033
		[SProperty(58)]
		public uint abnormalResistFrozen;

		// Token: 0x04001F62 RID: 8034
		[SProperty(59)]
		public uint abnormalResistSleep;

		// Token: 0x04001F63 RID: 8035
		[SProperty(60)]
		public uint abnormalResistConfunse;

		// Token: 0x04001F64 RID: 8036
		[SProperty(61)]
		public uint abnormalResistStrain;

		// Token: 0x04001F65 RID: 8037
		[SProperty(62)]
		public uint abnormalResistSpeedDown;

		// Token: 0x04001F66 RID: 8038
		[SProperty(63)]
		public uint abnormalResistCurse;

		// Token: 0x04001F67 RID: 8039
		[SProperty(64)]
		public uint transferStone;

		// Token: 0x04001F68 RID: 8040
		[SProperty(65)]
		public uint recoScore;

		// Token: 0x04001F69 RID: 8041
		[SProperty(66)]
		public uint lockItem;

		// Token: 0x04001F6A RID: 8042
		[SProperty(67)]
		public PreciousBeadMountHole[] preciousBeadHoles = new PreciousBeadMountHole[(int)Item.MAX_PRECBEAD_MOUNTHOLE_NUM];

		// Token: 0x04001F6B RID: 8043
		[SProperty(68)]
		public uint auctionCoolTimeStamp;

		// Token: 0x04001F6C RID: 8044
		[SProperty(69)]
		public byte isTreas;

		// Token: 0x04001F6D RID: 8045
		[SProperty(70)]
		public uint beadExtipreCnt;

		// Token: 0x04001F6E RID: 8046
		[SProperty(71)]
		public uint beadReplaceCnt;

		// Token: 0x04001F6F RID: 8047
		[SProperty(72)]
		public uint tableID;

		// Token: 0x04001F70 RID: 8048
		[SProperty(73)]
		public byte equipType;

		// Token: 0x04001F71 RID: 8049
		[SProperty(74)]
		public byte enhanceType;

		// Token: 0x04001F72 RID: 8050
		[SProperty(75)]
		public uint enhanceNum;

		// Token: 0x04001F73 RID: 8051
		[SProperty(76)]
		public uint enhanceFailed;

		// Token: 0x04001F74 RID: 8052
		[SProperty(77)]
		public uint auctionTransNum;

		// Token: 0x04001F75 RID: 8053
		[SProperty(78)]
		public InscriptionMountHole[] inscriptionHoles;

		// Token: 0x04001F76 RID: 8054
		[SProperty(79)]
		public uint independAtk;

		// Token: 0x04001F77 RID: 8055
		[SProperty(80)]
		public uint independAtkStreng;

		// Token: 0x04001F78 RID: 8056
		[SProperty(81)]
		public byte subtype;
	}
}
