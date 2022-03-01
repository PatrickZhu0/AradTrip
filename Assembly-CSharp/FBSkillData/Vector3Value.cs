using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2E RID: 19246
	public sealed class Vector3Value : Table
	{
		// Token: 0x0601C22A RID: 115242 RVA: 0x0089333A File Offset: 0x0089173A
		public static Vector3Value GetRootAsVector3Value(ByteBuffer _bb)
		{
			return Vector3Value.GetRootAsVector3Value(_bb, new Vector3Value());
		}

		// Token: 0x0601C22B RID: 115243 RVA: 0x00893347 File Offset: 0x00891747
		public static Vector3Value GetRootAsVector3Value(ByteBuffer _bb, Vector3Value obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C22C RID: 115244 RVA: 0x00893363 File Offset: 0x00891763
		public Vector3Value __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F5 RID: 9973
		// (get) Token: 0x0601C22D RID: 115245 RVA: 0x00893374 File Offset: 0x00891774
		public Vector3 Value
		{
			get
			{
				return this.GetValue(new Vector3());
			}
		}

		// Token: 0x0601C22E RID: 115246 RVA: 0x00893384 File Offset: 0x00891784
		public Vector3 GetValue(Vector3 obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C22F RID: 115247 RVA: 0x008933B9 File Offset: 0x008917B9
		public static void StartVector3Value(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C230 RID: 115248 RVA: 0x008933C2 File Offset: 0x008917C2
		public static void AddValue(FlatBufferBuilder builder, Offset<Vector3> valueOffset)
		{
			builder.AddStruct(0, valueOffset.Value, 0);
		}

		// Token: 0x0601C231 RID: 115249 RVA: 0x008933D4 File Offset: 0x008917D4
		public static Offset<Vector3Value> EndVector3Value(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<Vector3Value>(value);
		}
	}
}
