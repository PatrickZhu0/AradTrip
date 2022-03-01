using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000423 RID: 1059
	public class FaceTable : IFlatbufferObject
	{
		// Token: 0x17000C51 RID: 3153
		// (get) Token: 0x0600327C RID: 12924 RVA: 0x000B27F0 File Offset: 0x000B0BF0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600327D RID: 12925 RVA: 0x000B27FD File Offset: 0x000B0BFD
		public static FaceTable GetRootAsFaceTable(ByteBuffer _bb)
		{
			return FaceTable.GetRootAsFaceTable(_bb, new FaceTable());
		}

		// Token: 0x0600327E RID: 12926 RVA: 0x000B280A File Offset: 0x000B0C0A
		public static FaceTable GetRootAsFaceTable(ByteBuffer _bb, FaceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x000B2826 File Offset: 0x000B0C26
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x000B2840 File Offset: 0x000B0C40
		public FaceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C52 RID: 3154
		// (get) Token: 0x06003281 RID: 12929 RVA: 0x000B284C File Offset: 0x000B0C4C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (122095523 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C53 RID: 3155
		// (get) Token: 0x06003282 RID: 12930 RVA: 0x000B2898 File Offset: 0x000B0C98
		public FaceTable.eGroup Group
		{
			get
			{
				int num = this.__p.__offset(6);
				return (FaceTable.eGroup)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C54 RID: 3156
		// (get) Token: 0x06003283 RID: 12931 RVA: 0x000B28DC File Offset: 0x000B0CDC
		public string Path
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003284 RID: 12932 RVA: 0x000B291E File Offset: 0x000B0D1E
		public ArraySegment<byte>? GetPathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06003285 RID: 12933 RVA: 0x000B292C File Offset: 0x000B0D2C
		public static Offset<FaceTable> CreateFaceTable(FlatBufferBuilder builder, int ID = 0, FaceTable.eGroup Group = FaceTable.eGroup.Team, StringOffset PathOffset = default(StringOffset))
		{
			builder.StartObject(3);
			FaceTable.AddPath(builder, PathOffset);
			FaceTable.AddGroup(builder, Group);
			FaceTable.AddID(builder, ID);
			return FaceTable.EndFaceTable(builder);
		}

		// Token: 0x06003286 RID: 12934 RVA: 0x000B2950 File Offset: 0x000B0D50
		public static void StartFaceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06003287 RID: 12935 RVA: 0x000B2959 File Offset: 0x000B0D59
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003288 RID: 12936 RVA: 0x000B2964 File Offset: 0x000B0D64
		public static void AddGroup(FlatBufferBuilder builder, FaceTable.eGroup Group)
		{
			builder.AddInt(1, (int)Group, 0);
		}

		// Token: 0x06003289 RID: 12937 RVA: 0x000B296F File Offset: 0x000B0D6F
		public static void AddPath(FlatBufferBuilder builder, StringOffset PathOffset)
		{
			builder.AddOffset(2, PathOffset.Value, 0);
		}

		// Token: 0x0600328A RID: 12938 RVA: 0x000B2980 File Offset: 0x000B0D80
		public static Offset<FaceTable> EndFaceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FaceTable>(value);
		}

		// Token: 0x0600328B RID: 12939 RVA: 0x000B299A File Offset: 0x000B0D9A
		public static void FinishFaceTableBuffer(FlatBufferBuilder builder, Offset<FaceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014C6 RID: 5318
		private Table __p = new Table();

		// Token: 0x02000424 RID: 1060
		public enum eGroup
		{
			// Token: 0x040014C8 RID: 5320
			Team,
			// Token: 0x040014C9 RID: 5321
			Normal
		}

		// Token: 0x02000425 RID: 1061
		public enum eCrypt
		{
			// Token: 0x040014CB RID: 5323
			code = 122095523
		}
	}
}
