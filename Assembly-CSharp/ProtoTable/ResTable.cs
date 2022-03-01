using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000582 RID: 1410
	public class ResTable : IFlatbufferObject
	{
		// Token: 0x17001392 RID: 5010
		// (get) Token: 0x0600486E RID: 18542 RVA: 0x000E5D78 File Offset: 0x000E4178
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600486F RID: 18543 RVA: 0x000E5D85 File Offset: 0x000E4185
		public static ResTable GetRootAsResTable(ByteBuffer _bb)
		{
			return ResTable.GetRootAsResTable(_bb, new ResTable());
		}

		// Token: 0x06004870 RID: 18544 RVA: 0x000E5D92 File Offset: 0x000E4192
		public static ResTable GetRootAsResTable(ByteBuffer _bb, ResTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004871 RID: 18545 RVA: 0x000E5DAE File Offset: 0x000E41AE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004872 RID: 18546 RVA: 0x000E5DC8 File Offset: 0x000E41C8
		public ResTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001393 RID: 5011
		// (get) Token: 0x06004873 RID: 18547 RVA: 0x000E5DD4 File Offset: 0x000E41D4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (482489050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001394 RID: 5012
		// (get) Token: 0x06004874 RID: 18548 RVA: 0x000E5E20 File Offset: 0x000E4220
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004875 RID: 18549 RVA: 0x000E5E62 File Offset: 0x000E4262
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001395 RID: 5013
		// (get) Token: 0x06004876 RID: 18550 RVA: 0x000E5E70 File Offset: 0x000E4270
		public ResTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ResTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001396 RID: 5014
		// (get) Token: 0x06004877 RID: 18551 RVA: 0x000E5EB4 File Offset: 0x000E42B4
		public bool newFashion
		{
			get
			{
				int num = this.__p.__offset(10);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001397 RID: 5015
		// (get) Token: 0x06004878 RID: 18552 RVA: 0x000E5F00 File Offset: 0x000E4300
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004879 RID: 18553 RVA: 0x000E5F43 File Offset: 0x000E4343
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001398 RID: 5016
		// (get) Token: 0x0600487A RID: 18554 RVA: 0x000E5F54 File Offset: 0x000E4354
		public string ParentName
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600487B RID: 18555 RVA: 0x000E5F97 File Offset: 0x000E4397
		public ArraySegment<byte>? GetParentNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001399 RID: 5017
		// (get) Token: 0x0600487C RID: 18556 RVA: 0x000E5FA8 File Offset: 0x000E43A8
		public string ModelPath
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600487D RID: 18557 RVA: 0x000E5FEB File Offset: 0x000E43EB
		public ArraySegment<byte>? GetModelPathBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600487E RID: 18558 RVA: 0x000E5FFC File Offset: 0x000E43FC
		public string ActionConfigPathArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700139A RID: 5018
		// (get) Token: 0x0600487F RID: 18559 RVA: 0x000E6044 File Offset: 0x000E4444
		public int ActionConfigPathLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700139B RID: 5019
		// (get) Token: 0x06004880 RID: 18560 RVA: 0x000E6077 File Offset: 0x000E4477
		public FlatBufferArray<string> ActionConfigPath
		{
			get
			{
				if (this.ActionConfigPathValue == null)
				{
					this.ActionConfigPathValue = new FlatBufferArray<string>(new Func<int, string>(this.ActionConfigPathArray), this.ActionConfigPathLength);
				}
				return this.ActionConfigPathValue;
			}
		}

		// Token: 0x1700139C RID: 5020
		// (get) Token: 0x06004881 RID: 18561 RVA: 0x000E60A8 File Offset: 0x000E44A8
		public string ActionConfigPath2
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004882 RID: 18562 RVA: 0x000E60EB File Offset: 0x000E44EB
		public ArraySegment<byte>? GetActionConfigPath2Bytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700139D RID: 5021
		// (get) Token: 0x06004883 RID: 18563 RVA: 0x000E60FC File Offset: 0x000E44FC
		public int WeaponHitSFX
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (482489050 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004884 RID: 18564 RVA: 0x000E6148 File Offset: 0x000E4548
		public static Offset<ResTable> CreateResTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), ResTable.eType Type = ResTable.eType.Type_None, bool newFashion = false, StringOffset IconPathOffset = default(StringOffset), StringOffset ParentNameOffset = default(StringOffset), StringOffset ModelPathOffset = default(StringOffset), VectorOffset ActionConfigPathOffset = default(VectorOffset), StringOffset ActionConfigPath2Offset = default(StringOffset), int WeaponHitSFX = 0)
		{
			builder.StartObject(10);
			ResTable.AddWeaponHitSFX(builder, WeaponHitSFX);
			ResTable.AddActionConfigPath2(builder, ActionConfigPath2Offset);
			ResTable.AddActionConfigPath(builder, ActionConfigPathOffset);
			ResTable.AddModelPath(builder, ModelPathOffset);
			ResTable.AddParentName(builder, ParentNameOffset);
			ResTable.AddIconPath(builder, IconPathOffset);
			ResTable.AddType(builder, Type);
			ResTable.AddName(builder, NameOffset);
			ResTable.AddID(builder, ID);
			ResTable.AddNewFashion(builder, newFashion);
			return ResTable.EndResTable(builder);
		}

		// Token: 0x06004885 RID: 18565 RVA: 0x000E61B0 File Offset: 0x000E45B0
		public static void StartResTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x06004886 RID: 18566 RVA: 0x000E61BA File Offset: 0x000E45BA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004887 RID: 18567 RVA: 0x000E61C5 File Offset: 0x000E45C5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004888 RID: 18568 RVA: 0x000E61D6 File Offset: 0x000E45D6
		public static void AddType(FlatBufferBuilder builder, ResTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06004889 RID: 18569 RVA: 0x000E61E1 File Offset: 0x000E45E1
		public static void AddNewFashion(FlatBufferBuilder builder, bool newFashion)
		{
			builder.AddBool(3, newFashion, false);
		}

		// Token: 0x0600488A RID: 18570 RVA: 0x000E61EC File Offset: 0x000E45EC
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(4, IconPathOffset.Value, 0);
		}

		// Token: 0x0600488B RID: 18571 RVA: 0x000E61FD File Offset: 0x000E45FD
		public static void AddParentName(FlatBufferBuilder builder, StringOffset ParentNameOffset)
		{
			builder.AddOffset(5, ParentNameOffset.Value, 0);
		}

		// Token: 0x0600488C RID: 18572 RVA: 0x000E620E File Offset: 0x000E460E
		public static void AddModelPath(FlatBufferBuilder builder, StringOffset ModelPathOffset)
		{
			builder.AddOffset(6, ModelPathOffset.Value, 0);
		}

		// Token: 0x0600488D RID: 18573 RVA: 0x000E621F File Offset: 0x000E461F
		public static void AddActionConfigPath(FlatBufferBuilder builder, VectorOffset ActionConfigPathOffset)
		{
			builder.AddOffset(7, ActionConfigPathOffset.Value, 0);
		}

		// Token: 0x0600488E RID: 18574 RVA: 0x000E6230 File Offset: 0x000E4630
		public static VectorOffset CreateActionConfigPathVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600488F RID: 18575 RVA: 0x000E6276 File Offset: 0x000E4676
		public static void StartActionConfigPathVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004890 RID: 18576 RVA: 0x000E6281 File Offset: 0x000E4681
		public static void AddActionConfigPath2(FlatBufferBuilder builder, StringOffset ActionConfigPath2Offset)
		{
			builder.AddOffset(8, ActionConfigPath2Offset.Value, 0);
		}

		// Token: 0x06004891 RID: 18577 RVA: 0x000E6292 File Offset: 0x000E4692
		public static void AddWeaponHitSFX(FlatBufferBuilder builder, int WeaponHitSFX)
		{
			builder.AddInt(9, WeaponHitSFX, 0);
		}

		// Token: 0x06004892 RID: 18578 RVA: 0x000E62A0 File Offset: 0x000E46A0
		public static Offset<ResTable> EndResTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ResTable>(value);
		}

		// Token: 0x06004893 RID: 18579 RVA: 0x000E62BA File Offset: 0x000E46BA
		public static void FinishResTableBuffer(FlatBufferBuilder builder, Offset<ResTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AA6 RID: 6822
		private Table __p = new Table();

		// Token: 0x04001AA7 RID: 6823
		private FlatBufferArray<string> ActionConfigPathValue;

		// Token: 0x02000583 RID: 1411
		public enum eType
		{
			// Token: 0x04001AA9 RID: 6825
			Type_None,
			// Token: 0x04001AAA RID: 6826
			ACTOR,
			// Token: 0x04001AAB RID: 6827
			ENTITY,
			// Token: 0x04001AAC RID: 6828
			DESTROYABLE,
			// Token: 0x04001AAD RID: 6829
			DECORATOR,
			// Token: 0x04001AAE RID: 6830
			EQUIP
		}

		// Token: 0x02000584 RID: 1412
		public enum eCrypt
		{
			// Token: 0x04001AB0 RID: 6832
			code = 482489050
		}
	}
}
