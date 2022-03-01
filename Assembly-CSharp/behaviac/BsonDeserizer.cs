using System;
using System.IO;
using System.Text;

namespace behaviac
{
	// Token: 0x02004845 RID: 18501
	public class BsonDeserizer
	{
		// Token: 0x0601A968 RID: 108904 RVA: 0x00838498 File Offset: 0x00836898
		public bool Init(byte[] pBuffer)
		{
			try
			{
				this.m_pBuffer = pBuffer;
				if (this.m_pBuffer != null && this.m_pBuffer.Length > 0)
				{
					this.m_BinaryReader = new BinaryReader(new MemoryStream(this.m_pBuffer));
					if (this.OpenDocument())
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A969 RID: 108905 RVA: 0x0083850C File Offset: 0x0083690C
		private int GetCurrentIndex()
		{
			return (int)this.m_BinaryReader.BaseStream.Position;
		}

		// Token: 0x0601A96A RID: 108906 RVA: 0x00838520 File Offset: 0x00836920
		public bool OpenDocument()
		{
			int currentIndex = this.GetCurrentIndex();
			int num = this.ReadInt32();
			int num2 = currentIndex + num - 1;
			return this.m_pBuffer[num2] == 0;
		}

		// Token: 0x0601A96B RID: 108907 RVA: 0x00838554 File Offset: 0x00836954
		public void CloseDocument(bool bEatEod)
		{
			int num = this.GetCurrentIndex();
			if (bEatEod)
			{
				this.m_BinaryReader.BaseStream.Position += 1L;
			}
			else
			{
				num--;
			}
		}

		// Token: 0x0601A96C RID: 108908 RVA: 0x00838590 File Offset: 0x00836990
		public BsonDeserizer.BsonTypes ReadType()
		{
			return (BsonDeserizer.BsonTypes)this.m_BinaryReader.ReadByte();
		}

		// Token: 0x0601A96D RID: 108909 RVA: 0x008385AC File Offset: 0x008369AC
		public int ReadInt32()
		{
			return this.m_BinaryReader.ReadInt32();
		}

		// Token: 0x0601A96E RID: 108910 RVA: 0x008385C8 File Offset: 0x008369C8
		public ushort ReadUInt16()
		{
			return this.m_BinaryReader.ReadUInt16();
		}

		// Token: 0x0601A96F RID: 108911 RVA: 0x008385E4 File Offset: 0x008369E4
		public float ReadFloat()
		{
			return this.m_BinaryReader.ReadSingle();
		}

		// Token: 0x0601A970 RID: 108912 RVA: 0x00838600 File Offset: 0x00836A00
		public bool ReadBool()
		{
			return this.m_BinaryReader.ReadByte() != 0;
		}

		// Token: 0x0601A971 RID: 108913 RVA: 0x00838628 File Offset: 0x00836A28
		public string ReadString()
		{
			ushort num = this.ReadUInt16();
			byte[] bytes = this.m_BinaryReader.ReadBytes((int)num);
			return Encoding.UTF8.GetString(bytes, 0, (int)(num - 1));
		}

		// Token: 0x0601A972 RID: 108914 RVA: 0x0083865C File Offset: 0x00836A5C
		public bool eod()
		{
			byte b = this.m_pBuffer[this.GetCurrentIndex()];
			return b == 0;
		}

		// Token: 0x0401296F RID: 76143
		private byte[] m_pBuffer;

		// Token: 0x04012970 RID: 76144
		private BinaryReader m_BinaryReader;

		// Token: 0x02004846 RID: 18502
		public enum BsonTypes
		{
			// Token: 0x04012972 RID: 76146
			BT_None,
			// Token: 0x04012973 RID: 76147
			BT_Double,
			// Token: 0x04012974 RID: 76148
			BT_String,
			// Token: 0x04012975 RID: 76149
			BT_Object,
			// Token: 0x04012976 RID: 76150
			BT_Array,
			// Token: 0x04012977 RID: 76151
			BT_Binary,
			// Token: 0x04012978 RID: 76152
			BT_Undefined,
			// Token: 0x04012979 RID: 76153
			BT_ObjectId,
			// Token: 0x0401297A RID: 76154
			BT_Boolean,
			// Token: 0x0401297B RID: 76155
			BT_DateTime,
			// Token: 0x0401297C RID: 76156
			BT_Null,
			// Token: 0x0401297D RID: 76157
			BT_Regex,
			// Token: 0x0401297E RID: 76158
			BT_Reference,
			// Token: 0x0401297F RID: 76159
			BT_Code,
			// Token: 0x04012980 RID: 76160
			BT_Symbol,
			// Token: 0x04012981 RID: 76161
			BT_ScopedCode,
			// Token: 0x04012982 RID: 76162
			BT_Int32,
			// Token: 0x04012983 RID: 76163
			BT_Timestamp,
			// Token: 0x04012984 RID: 76164
			BT_Int64,
			// Token: 0x04012985 RID: 76165
			BT_Float,
			// Token: 0x04012986 RID: 76166
			BT_Element,
			// Token: 0x04012987 RID: 76167
			BT_Set,
			// Token: 0x04012988 RID: 76168
			BT_BehaviorElement,
			// Token: 0x04012989 RID: 76169
			BT_PropertiesElement,
			// Token: 0x0401298A RID: 76170
			BT_ParsElement,
			// Token: 0x0401298B RID: 76171
			BT_ParElement,
			// Token: 0x0401298C RID: 76172
			BT_NodeElement,
			// Token: 0x0401298D RID: 76173
			BT_AttachmentsElement,
			// Token: 0x0401298E RID: 76174
			BT_AttachmentElement,
			// Token: 0x0401298F RID: 76175
			BT_AgentsElement,
			// Token: 0x04012990 RID: 76176
			BT_AgentElement,
			// Token: 0x04012991 RID: 76177
			BT_PropertyElement,
			// Token: 0x04012992 RID: 76178
			BT_MethodsElement,
			// Token: 0x04012993 RID: 76179
			BT_MethodElement,
			// Token: 0x04012994 RID: 76180
			BT_Custom,
			// Token: 0x04012995 RID: 76181
			BT_ParameterElement
		}
	}
}
