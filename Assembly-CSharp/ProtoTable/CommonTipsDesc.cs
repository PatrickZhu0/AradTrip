using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000361 RID: 865
	public class CommonTipsDesc : IFlatbufferObject
	{
		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x0600250B RID: 9483 RVA: 0x000924D8 File Offset: 0x000908D8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x000924E5 File Offset: 0x000908E5
		public static CommonTipsDesc GetRootAsCommonTipsDesc(ByteBuffer _bb)
		{
			return CommonTipsDesc.GetRootAsCommonTipsDesc(_bb, new CommonTipsDesc());
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x000924F2 File Offset: 0x000908F2
		public static CommonTipsDesc GetRootAsCommonTipsDesc(ByteBuffer _bb, CommonTipsDesc obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x0009250E File Offset: 0x0009090E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x00092528 File Offset: 0x00090928
		public CommonTipsDesc __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06002510 RID: 9488 RVA: 0x00092534 File Offset: 0x00090934
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-884783574 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06002511 RID: 9489 RVA: 0x00092580 File Offset: 0x00090980
		public string Descs
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x000925C2 File Offset: 0x000909C2
		public ArraySegment<byte>? GetDescsBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06002513 RID: 9491 RVA: 0x000925D0 File Offset: 0x000909D0
		public CommonTipsDesc.eShowType ShowType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (CommonTipsDesc.eShowType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06002514 RID: 9492 RVA: 0x00092614 File Offset: 0x00090A14
		public CommonTipsDesc.eShowMode ShowMode
		{
			get
			{
				int num = this.__p.__offset(10);
				return (CommonTipsDesc.eShowMode)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06002515 RID: 9493 RVA: 0x00092658 File Offset: 0x00090A58
		public string TitleText
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x0009269B File Offset: 0x00090A9B
		public ArraySegment<byte>? GetTitleTextBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06002517 RID: 9495 RVA: 0x000926AC File Offset: 0x00090AAC
		public string ButtonText
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x000926EF File Offset: 0x00090AEF
		public ArraySegment<byte>? GetButtonTextBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06002519 RID: 9497 RVA: 0x00092700 File Offset: 0x00090B00
		public string CancelBtnText
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00092743 File Offset: 0x00090B43
		public ArraySegment<byte>? GetCancelBtnTextBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x00092754 File Offset: 0x00090B54
		public static Offset<CommonTipsDesc> CreateCommonTipsDesc(FlatBufferBuilder builder, int ID = 0, StringOffset DescsOffset = default(StringOffset), CommonTipsDesc.eShowType ShowType = CommonTipsDesc.eShowType.ShowType_None, CommonTipsDesc.eShowMode ShowMode = CommonTipsDesc.eShowMode.SI_NULL, StringOffset TitleTextOffset = default(StringOffset), StringOffset ButtonTextOffset = default(StringOffset), StringOffset CancelBtnTextOffset = default(StringOffset))
		{
			builder.StartObject(7);
			CommonTipsDesc.AddCancelBtnText(builder, CancelBtnTextOffset);
			CommonTipsDesc.AddButtonText(builder, ButtonTextOffset);
			CommonTipsDesc.AddTitleText(builder, TitleTextOffset);
			CommonTipsDesc.AddShowMode(builder, ShowMode);
			CommonTipsDesc.AddShowType(builder, ShowType);
			CommonTipsDesc.AddDescs(builder, DescsOffset);
			CommonTipsDesc.AddID(builder, ID);
			return CommonTipsDesc.EndCommonTipsDesc(builder);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x000927A3 File Offset: 0x00090BA3
		public static void StartCommonTipsDesc(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x000927AC File Offset: 0x00090BAC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x000927B7 File Offset: 0x00090BB7
		public static void AddDescs(FlatBufferBuilder builder, StringOffset DescsOffset)
		{
			builder.AddOffset(1, DescsOffset.Value, 0);
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x000927C8 File Offset: 0x00090BC8
		public static void AddShowType(FlatBufferBuilder builder, CommonTipsDesc.eShowType ShowType)
		{
			builder.AddInt(2, (int)ShowType, 0);
		}

		// Token: 0x06002520 RID: 9504 RVA: 0x000927D3 File Offset: 0x00090BD3
		public static void AddShowMode(FlatBufferBuilder builder, CommonTipsDesc.eShowMode ShowMode)
		{
			builder.AddInt(3, (int)ShowMode, 0);
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x000927DE File Offset: 0x00090BDE
		public static void AddTitleText(FlatBufferBuilder builder, StringOffset TitleTextOffset)
		{
			builder.AddOffset(4, TitleTextOffset.Value, 0);
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x000927EF File Offset: 0x00090BEF
		public static void AddButtonText(FlatBufferBuilder builder, StringOffset ButtonTextOffset)
		{
			builder.AddOffset(5, ButtonTextOffset.Value, 0);
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x00092800 File Offset: 0x00090C00
		public static void AddCancelBtnText(FlatBufferBuilder builder, StringOffset CancelBtnTextOffset)
		{
			builder.AddOffset(6, CancelBtnTextOffset.Value, 0);
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x00092814 File Offset: 0x00090C14
		public static Offset<CommonTipsDesc> EndCommonTipsDesc(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CommonTipsDesc>(value);
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x0009282E File Offset: 0x00090C2E
		public static void FinishCommonTipsDescBuffer(FlatBufferBuilder builder, Offset<CommonTipsDesc> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400112C RID: 4396
		private Table __p = new Table();

		// Token: 0x02000362 RID: 866
		public enum eShowType
		{
			// Token: 0x0400112E RID: 4398
			ShowType_None,
			// Token: 0x0400112F RID: 4399
			CT_MSG_BOX_OK,
			// Token: 0x04001130 RID: 4400
			CT_MSG_BOX_OK_CANCEL,
			// Token: 0x04001131 RID: 4401
			CT_MSG_BOX_CANCEL_OK,
			// Token: 0x04001132 RID: 4402
			CT_CLICK_CONFIRM_FRAME = 10,
			// Token: 0x04001133 RID: 4403
			CT_SYSTEM_TEXT_ANIMATION = 20,
			// Token: 0x04001134 RID: 4404
			CT_TEXT_FLOAT_EFFECT,
			// Token: 0x04001135 RID: 4405
			CT_SCROLL_LIGHT = 100,
			// Token: 0x04001136 RID: 4406
			CT_DUNGEON_TEXT_ANIMATION = 40,
			// Token: 0x04001137 RID: 4407
			CT_DUNGEON_TEXT_ANIMATION_2,
			// Token: 0x04001138 RID: 4408
			CT_HOT_UPDATE_OK = 101,
			// Token: 0x04001139 RID: 4409
			CT_HOT_UPDATE_OK_CANCEL
		}

		// Token: 0x02000363 RID: 867
		public enum eShowMode
		{
			// Token: 0x0400113B RID: 4411
			SI_NULL,
			// Token: 0x0400113C RID: 4412
			SI_UNIQUE,
			// Token: 0x0400113D RID: 4413
			SI_IMMEDIATELY,
			// Token: 0x0400113E RID: 4414
			SI_QUEUE
		}

		// Token: 0x02000364 RID: 868
		public enum eCrypt
		{
			// Token: 0x04001140 RID: 4416
			code = -884783574
		}
	}
}
