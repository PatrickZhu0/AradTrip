using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2C RID: 19244
	public sealed class QuaternionValue : Table
	{
		// Token: 0x0601C218 RID: 115224 RVA: 0x008931C2 File Offset: 0x008915C2
		public static QuaternionValue GetRootAsQuaternionValue(ByteBuffer _bb)
		{
			return QuaternionValue.GetRootAsQuaternionValue(_bb, new QuaternionValue());
		}

		// Token: 0x0601C219 RID: 115225 RVA: 0x008931CF File Offset: 0x008915CF
		public static QuaternionValue GetRootAsQuaternionValue(ByteBuffer _bb, QuaternionValue obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C21A RID: 115226 RVA: 0x008931EB File Offset: 0x008915EB
		public QuaternionValue __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F3 RID: 9971
		// (get) Token: 0x0601C21B RID: 115227 RVA: 0x008931FC File Offset: 0x008915FC
		public Quaternion Value
		{
			get
			{
				return this.GetValue(new Quaternion());
			}
		}

		// Token: 0x0601C21C RID: 115228 RVA: 0x0089320C File Offset: 0x0089160C
		public Quaternion GetValue(Quaternion obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C21D RID: 115229 RVA: 0x00893241 File Offset: 0x00891641
		public static void StartQuaternionValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C21E RID: 115230 RVA: 0x0089324A File Offset: 0x0089164A
		public static void AddValue(FlatBufferBuilder builder, Offset<Quaternion> valueOffset)
		{
			builder.AddStruct(0, valueOffset.Value, 0);
		}

		// Token: 0x0601C21F RID: 115231 RVA: 0x0089325C File Offset: 0x0089165C
		public static Offset<QuaternionValue> EndQuaternionValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<QuaternionValue>(value);
		}
	}
}
