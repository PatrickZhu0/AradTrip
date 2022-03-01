using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004C8 RID: 1224
	public class JarItemPool : IFlatbufferObject
	{
		// Token: 0x17000F80 RID: 3968
		// (get) Token: 0x06003C4D RID: 15437 RVA: 0x000C93C8 File Offset: 0x000C77C8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003C4E RID: 15438 RVA: 0x000C93D5 File Offset: 0x000C77D5
		public static JarItemPool GetRootAsJarItemPool(ByteBuffer _bb)
		{
			return JarItemPool.GetRootAsJarItemPool(_bb, new JarItemPool());
		}

		// Token: 0x06003C4F RID: 15439 RVA: 0x000C93E2 File Offset: 0x000C77E2
		public static JarItemPool GetRootAsJarItemPool(ByteBuffer _bb, JarItemPool obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003C50 RID: 15440 RVA: 0x000C93FE File Offset: 0x000C77FE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003C51 RID: 15441 RVA: 0x000C9418 File Offset: 0x000C7818
		public JarItemPool __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000F81 RID: 3969
		// (get) Token: 0x06003C52 RID: 15442 RVA: 0x000C9424 File Offset: 0x000C7824
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F82 RID: 3970
		// (get) Token: 0x06003C53 RID: 15443 RVA: 0x000C9470 File Offset: 0x000C7870
		public int JarType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F83 RID: 3971
		// (get) Token: 0x06003C54 RID: 15444 RVA: 0x000C94BC File Offset: 0x000C78BC
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003C55 RID: 15445 RVA: 0x000C9508 File Offset: 0x000C7908
		public int StrengthArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F84 RID: 3972
		// (get) Token: 0x06003C56 RID: 15446 RVA: 0x000C9558 File Offset: 0x000C7958
		public int StrengthLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003C57 RID: 15447 RVA: 0x000C958B File Offset: 0x000C798B
		public ArraySegment<byte>? GetStrengthBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000F85 RID: 3973
		// (get) Token: 0x06003C58 RID: 15448 RVA: 0x000C959A File Offset: 0x000C799A
		public FlatBufferArray<int> Strength
		{
			get
			{
				if (this.StrengthValue == null)
				{
					this.StrengthValue = new FlatBufferArray<int>(new Func<int, int>(this.StrengthArray), this.StrengthLength);
				}
				return this.StrengthValue;
			}
		}

		// Token: 0x06003C59 RID: 15449 RVA: 0x000C95CC File Offset: 0x000C79CC
		public int OccuArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F86 RID: 3974
		// (get) Token: 0x06003C5A RID: 15450 RVA: 0x000C961C File Offset: 0x000C7A1C
		public int OccuLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003C5B RID: 15451 RVA: 0x000C964F File Offset: 0x000C7A4F
		public ArraySegment<byte>? GetOccuBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000F87 RID: 3975
		// (get) Token: 0x06003C5C RID: 15452 RVA: 0x000C965E File Offset: 0x000C7A5E
		public FlatBufferArray<int> Occu
		{
			get
			{
				if (this.OccuValue == null)
				{
					this.OccuValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuArray), this.OccuLength);
				}
				return this.OccuValue;
			}
		}

		// Token: 0x17000F88 RID: 3976
		// (get) Token: 0x06003C5D RID: 15453 RVA: 0x000C9690 File Offset: 0x000C7A90
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F89 RID: 3977
		// (get) Token: 0x06003C5E RID: 15454 RVA: 0x000C96DC File Offset: 0x000C7ADC
		public int ItemWeight
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8A RID: 3978
		// (get) Token: 0x06003C5F RID: 15455 RVA: 0x000C9728 File Offset: 0x000C7B28
		public int fix1
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8B RID: 3979
		// (get) Token: 0x06003C60 RID: 15456 RVA: 0x000C9774 File Offset: 0x000C7B74
		public int fix2
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8C RID: 3980
		// (get) Token: 0x06003C61 RID: 15457 RVA: 0x000C97C0 File Offset: 0x000C7BC0
		public int fix2Num
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8D RID: 3981
		// (get) Token: 0x06003C62 RID: 15458 RVA: 0x000C980C File Offset: 0x000C7C0C
		public int fixMax
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8E RID: 3982
		// (get) Token: 0x06003C63 RID: 15459 RVA: 0x000C9858 File Offset: 0x000C7C58
		public int fixMin
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F8F RID: 3983
		// (get) Token: 0x06003C64 RID: 15460 RVA: 0x000C98A4 File Offset: 0x000C7CA4
		public int OpneCondition
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F90 RID: 3984
		// (get) Token: 0x06003C65 RID: 15461 RVA: 0x000C98F0 File Offset: 0x000C7CF0
		public int Charge
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F91 RID: 3985
		// (get) Token: 0x06003C66 RID: 15462 RVA: 0x000C993C File Offset: 0x000C7D3C
		public int GetNumLimite
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F92 RID: 3986
		// (get) Token: 0x06003C67 RID: 15463 RVA: 0x000C9988 File Offset: 0x000C7D88
		public int NeedAnounce
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F93 RID: 3987
		// (get) Token: 0x06003C68 RID: 15464 RVA: 0x000C99D4 File Offset: 0x000C7DD4
		public int ShowEffect
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F94 RID: 3988
		// (get) Token: 0x06003C69 RID: 15465 RVA: 0x000C9A20 File Offset: 0x000C7E20
		public int IsTreasure
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F95 RID: 3989
		// (get) Token: 0x06003C6A RID: 15466 RVA: 0x000C9A6C File Offset: 0x000C7E6C
		public int JarGiftNeedAnount
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (1795474756 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003C6B RID: 15467 RVA: 0x000C9AB8 File Offset: 0x000C7EB8
		public static Offset<JarItemPool> CreateJarItemPool(FlatBufferBuilder builder, int ID = 0, int JarType = 0, int ItemID = 0, VectorOffset StrengthOffset = default(VectorOffset), VectorOffset OccuOffset = default(VectorOffset), int ItemNum = 0, int ItemWeight = 0, int fix1 = 0, int fix2 = 0, int fix2Num = 0, int fixMax = 0, int fixMin = 0, int OpneCondition = 0, int Charge = 0, int GetNumLimite = 0, int NeedAnounce = 0, int ShowEffect = 0, int IsTreasure = 0, int JarGiftNeedAnount = 0)
		{
			builder.StartObject(19);
			JarItemPool.AddJarGiftNeedAnount(builder, JarGiftNeedAnount);
			JarItemPool.AddIsTreasure(builder, IsTreasure);
			JarItemPool.AddShowEffect(builder, ShowEffect);
			JarItemPool.AddNeedAnounce(builder, NeedAnounce);
			JarItemPool.AddGetNumLimite(builder, GetNumLimite);
			JarItemPool.AddCharge(builder, Charge);
			JarItemPool.AddOpneCondition(builder, OpneCondition);
			JarItemPool.AddFixMin(builder, fixMin);
			JarItemPool.AddFixMax(builder, fixMax);
			JarItemPool.AddFix2Num(builder, fix2Num);
			JarItemPool.AddFix2(builder, fix2);
			JarItemPool.AddFix1(builder, fix1);
			JarItemPool.AddItemWeight(builder, ItemWeight);
			JarItemPool.AddItemNum(builder, ItemNum);
			JarItemPool.AddOccu(builder, OccuOffset);
			JarItemPool.AddStrength(builder, StrengthOffset);
			JarItemPool.AddItemID(builder, ItemID);
			JarItemPool.AddJarType(builder, JarType);
			JarItemPool.AddID(builder, ID);
			return JarItemPool.EndJarItemPool(builder);
		}

		// Token: 0x06003C6C RID: 15468 RVA: 0x000C9B68 File Offset: 0x000C7F68
		public static void StartJarItemPool(FlatBufferBuilder builder)
		{
			builder.StartObject(19);
		}

		// Token: 0x06003C6D RID: 15469 RVA: 0x000C9B72 File Offset: 0x000C7F72
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003C6E RID: 15470 RVA: 0x000C9B7D File Offset: 0x000C7F7D
		public static void AddJarType(FlatBufferBuilder builder, int JarType)
		{
			builder.AddInt(1, JarType, 0);
		}

		// Token: 0x06003C6F RID: 15471 RVA: 0x000C9B88 File Offset: 0x000C7F88
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(2, ItemID, 0);
		}

		// Token: 0x06003C70 RID: 15472 RVA: 0x000C9B93 File Offset: 0x000C7F93
		public static void AddStrength(FlatBufferBuilder builder, VectorOffset StrengthOffset)
		{
			builder.AddOffset(3, StrengthOffset.Value, 0);
		}

		// Token: 0x06003C71 RID: 15473 RVA: 0x000C9BA4 File Offset: 0x000C7FA4
		public static VectorOffset CreateStrengthVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003C72 RID: 15474 RVA: 0x000C9BE1 File Offset: 0x000C7FE1
		public static void StartStrengthVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003C73 RID: 15475 RVA: 0x000C9BEC File Offset: 0x000C7FEC
		public static void AddOccu(FlatBufferBuilder builder, VectorOffset OccuOffset)
		{
			builder.AddOffset(4, OccuOffset.Value, 0);
		}

		// Token: 0x06003C74 RID: 15476 RVA: 0x000C9C00 File Offset: 0x000C8000
		public static VectorOffset CreateOccuVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003C75 RID: 15477 RVA: 0x000C9C3D File Offset: 0x000C803D
		public static void StartOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003C76 RID: 15478 RVA: 0x000C9C48 File Offset: 0x000C8048
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(5, ItemNum, 0);
		}

		// Token: 0x06003C77 RID: 15479 RVA: 0x000C9C53 File Offset: 0x000C8053
		public static void AddItemWeight(FlatBufferBuilder builder, int ItemWeight)
		{
			builder.AddInt(6, ItemWeight, 0);
		}

		// Token: 0x06003C78 RID: 15480 RVA: 0x000C9C5E File Offset: 0x000C805E
		public static void AddFix1(FlatBufferBuilder builder, int fix1)
		{
			builder.AddInt(7, fix1, 0);
		}

		// Token: 0x06003C79 RID: 15481 RVA: 0x000C9C69 File Offset: 0x000C8069
		public static void AddFix2(FlatBufferBuilder builder, int fix2)
		{
			builder.AddInt(8, fix2, 0);
		}

		// Token: 0x06003C7A RID: 15482 RVA: 0x000C9C74 File Offset: 0x000C8074
		public static void AddFix2Num(FlatBufferBuilder builder, int fix2Num)
		{
			builder.AddInt(9, fix2Num, 0);
		}

		// Token: 0x06003C7B RID: 15483 RVA: 0x000C9C80 File Offset: 0x000C8080
		public static void AddFixMax(FlatBufferBuilder builder, int fixMax)
		{
			builder.AddInt(10, fixMax, 0);
		}

		// Token: 0x06003C7C RID: 15484 RVA: 0x000C9C8C File Offset: 0x000C808C
		public static void AddFixMin(FlatBufferBuilder builder, int fixMin)
		{
			builder.AddInt(11, fixMin, 0);
		}

		// Token: 0x06003C7D RID: 15485 RVA: 0x000C9C98 File Offset: 0x000C8098
		public static void AddOpneCondition(FlatBufferBuilder builder, int OpneCondition)
		{
			builder.AddInt(12, OpneCondition, 0);
		}

		// Token: 0x06003C7E RID: 15486 RVA: 0x000C9CA4 File Offset: 0x000C80A4
		public static void AddCharge(FlatBufferBuilder builder, int Charge)
		{
			builder.AddInt(13, Charge, 0);
		}

		// Token: 0x06003C7F RID: 15487 RVA: 0x000C9CB0 File Offset: 0x000C80B0
		public static void AddGetNumLimite(FlatBufferBuilder builder, int GetNumLimite)
		{
			builder.AddInt(14, GetNumLimite, 0);
		}

		// Token: 0x06003C80 RID: 15488 RVA: 0x000C9CBC File Offset: 0x000C80BC
		public static void AddNeedAnounce(FlatBufferBuilder builder, int NeedAnounce)
		{
			builder.AddInt(15, NeedAnounce, 0);
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x000C9CC8 File Offset: 0x000C80C8
		public static void AddShowEffect(FlatBufferBuilder builder, int ShowEffect)
		{
			builder.AddInt(16, ShowEffect, 0);
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x000C9CD4 File Offset: 0x000C80D4
		public static void AddIsTreasure(FlatBufferBuilder builder, int IsTreasure)
		{
			builder.AddInt(17, IsTreasure, 0);
		}

		// Token: 0x06003C83 RID: 15491 RVA: 0x000C9CE0 File Offset: 0x000C80E0
		public static void AddJarGiftNeedAnount(FlatBufferBuilder builder, int JarGiftNeedAnount)
		{
			builder.AddInt(18, JarGiftNeedAnount, 0);
		}

		// Token: 0x06003C84 RID: 15492 RVA: 0x000C9CEC File Offset: 0x000C80EC
		public static Offset<JarItemPool> EndJarItemPool(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<JarItemPool>(value);
		}

		// Token: 0x06003C85 RID: 15493 RVA: 0x000C9D06 File Offset: 0x000C8106
		public static void FinishJarItemPoolBuffer(FlatBufferBuilder builder, Offset<JarItemPool> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017BA RID: 6074
		private Table __p = new Table();

		// Token: 0x040017BB RID: 6075
		private FlatBufferArray<int> StrengthValue;

		// Token: 0x040017BC RID: 6076
		private FlatBufferArray<int> OccuValue;

		// Token: 0x020004C9 RID: 1225
		public enum eCrypt
		{
			// Token: 0x040017BE RID: 6078
			code = 1795474756
		}
	}
}
