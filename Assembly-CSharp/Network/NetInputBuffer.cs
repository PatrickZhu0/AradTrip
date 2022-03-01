using System;
using System.Net;
using System.Runtime.InteropServices;

namespace Network
{
	// Token: 0x020001BE RID: 446
	public class NetInputBuffer
	{
		// Token: 0x06000E35 RID: 3637 RVA: 0x000491D8 File Offset: 0x000475D8
		public NetInputBuffer()
		{
			this.m_Head = 0;
			this.m_Tail = 0;
			this.m_Buffer = new byte[this.DEFAULTSOCKETOUTPUTBUFFERSIZE];
			this.m_BufferLen = this.DEFAULTSOCKETOUTPUTBUFFERSIZE;
			this.m_MaxBufferLen = this.DEFAULTSOCKETOUTPUTBUFFERSIZE;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x0004922D File Offset: 0x0004762D
		public byte[] GetRawBuffer()
		{
			return this.m_Buffer;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00049235 File Offset: 0x00047635
		public int GetCurrentOffset()
		{
			return this.m_Tail;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x0004923D File Offset: 0x0004763D
		public int GetCurrentSize()
		{
			return this.m_BufferLen - this.m_Tail;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x0004924C File Offset: 0x0004764C
		public bool Peek(ref byte[] buf, int len)
		{
			if (len == 0)
			{
				Logger.LogError("len == 0");
				return false;
			}
			int num = this.Length();
			if (len > num)
			{
				Logger.LogError(string.Concat(new object[]
				{
					"len > Length(): ",
					len,
					" > ",
					num
				}));
				return false;
			}
			int num2 = this.m_Head;
			for (int i = 0; i < len; i++)
			{
				buf[i] = this.m_Buffer[num2++];
				if (num2 == this.m_BufferLen)
				{
					num2 = 0;
				}
			}
			return true;
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000492E8 File Offset: 0x000476E8
		public int GetPackLength()
		{
			if (this.Length() < 10)
			{
				return 0;
			}
			ushort num = (ushort)((int)this.m_Buffer[this.m_Head] | (int)this.m_Buffer[this.m_Head + 1] << 8);
			return (int)((ushort)IPAddress.NetworkToHostOrder((short)num));
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00049331 File Offset: 0x00047731
		public int Read(ref byte[] buf, int len)
		{
			if (!this.Peek(ref buf, len))
			{
				return 0;
			}
			this.Skip(len);
			return len;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x0004934B File Offset: 0x0004774B
		public int ReadByte(ref byte buf)
		{
			if (this.Length() < 1)
			{
				return 0;
			}
			buf = this.m_Buffer[this.m_Head];
			this.Skip(1);
			return 1;
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x00049374 File Offset: 0x00047774
		public int ReadSByte(ref sbyte buf)
		{
			if (this.Length() < 1)
			{
				return 0;
			}
			byte b = this.m_Buffer[this.m_Head];
			this.Skip(1);
			buf = (sbyte)b;
			return 1;
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000493AC File Offset: 0x000477AC
		public int ReadShort(ref short buf)
		{
			if (this.Length() < 2)
			{
				return 0;
			}
			buf = (short)((int)this.m_Buffer[this.m_Head] | (int)this.m_Buffer[this.m_Head + 1] << 8);
			this.Skip(2);
			buf = IPAddress.NetworkToHostOrder(buf);
			return 2;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000493FC File Offset: 0x000477FC
		public int ReadUShort(ref ushort buf)
		{
			short num = 0;
			if (this.ReadShort(ref num) == 0)
			{
				return 0;
			}
			buf = (ushort)num;
			return 2;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00049420 File Offset: 0x00047820
		public int ReadInt(ref int buf)
		{
			if (this.Length() < 4)
			{
				return 0;
			}
			buf = ((int)this.m_Buffer[this.m_Head] | (int)this.m_Buffer[this.m_Head + 1] << 8 | (int)this.m_Buffer[this.m_Head + 2] << 16 | (int)this.m_Buffer[this.m_Head + 3] << 24);
			this.Skip(4);
			buf = IPAddress.NetworkToHostOrder(buf);
			return 4;
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x00049494 File Offset: 0x00047894
		public int ReadUint(ref uint buf)
		{
			int num = 0;
			if (this.ReadInt(ref num) == 0)
			{
				return 0;
			}
			buf = (uint)num;
			return 4;
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x000494B6 File Offset: 0x000478B6
		public int ReadFloat(ref float buf)
		{
			if (this.Length() < 4)
			{
				return 0;
			}
			buf = BitConverter.ToSingle(this.m_Buffer, this.m_Head);
			this.Skip(4);
			return 4;
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x000494E4 File Offset: 0x000478E4
		public int ReadStruct(ref object OutObject)
		{
			int num = Marshal.SizeOf(OutObject);
			byte[] array = new byte[num];
			if (this.Read(ref array, num) == 0)
			{
				return 0;
			}
			if (num > array.Length)
			{
				return 0;
			}
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.Copy(array, 0, intPtr, num);
			OutObject = Marshal.PtrToStructure(intPtr, OutObject.GetType());
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00049544 File Offset: 0x00047944
		public object ReadStruct(Type type)
		{
			int num = Marshal.SizeOf(type);
			byte[] array = new byte[num];
			if (this.Read(ref array, num) == 0)
			{
				return null;
			}
			if (num > array.Length)
			{
				return null;
			}
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.Copy(array, 0, intPtr, num);
			object result = Marshal.PtrToStructure(intPtr, type);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00049599 File Offset: 0x00047999
		public bool Find(ref byte[] buf)
		{
			return false;
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0004959C File Offset: 0x0004799C
		public bool Skip(int len)
		{
			if (len == 0)
			{
				return false;
			}
			if (len > this.Length())
			{
				return false;
			}
			this.m_Head = (this.m_Head + len) % this.m_BufferLen;
			if (this.m_Head == this.m_Tail)
			{
				this.m_Head = (this.m_Tail = 0);
			}
			return true;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x000495F8 File Offset: 0x000479F8
		public void Initsize()
		{
			this.m_Head = (this.m_Tail = 0);
			this.m_Buffer = new byte[this.DEFAULTSOCKETOUTPUTBUFFERSIZE];
			this.m_BufferLen = this.DEFAULTSOCKETOUTPUTBUFFERSIZE;
			this.m_MaxBufferLen = this.DEFAULTSOCKETOUTPUTBUFFERSIZE;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x0004963E File Offset: 0x00047A3E
		public bool Resize(int size)
		{
			return false;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00049641 File Offset: 0x00047A41
		public int Capacity()
		{
			return this.m_BufferLen;
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x0004964C File Offset: 0x00047A4C
		public int Length()
		{
			if (this.m_Head < this.m_Tail)
			{
				return this.m_Tail - this.m_Head;
			}
			if (this.m_Head > this.m_Tail)
			{
				return this.m_BufferLen - this.m_Head + this.m_Tail;
			}
			return 0;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x000496A0 File Offset: 0x00047AA0
		public void resetBuffer(bool isNotEnough)
		{
			try
			{
				if (isNotEnough)
				{
					Array.Copy(this.m_Buffer, this.m_Head, this.m_Buffer, 0, this.Length());
				}
				else
				{
					Array.Clear(this.m_Buffer, 0, this.m_Buffer.Length);
				}
				this.m_Tail = this.Length();
				this.m_Head = 0;
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00049718 File Offset: 0x00047B18
		public bool IsEmpty()
		{
			return this.m_Head == this.m_Tail;
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00049728 File Offset: 0x00047B28
		public void CleanUp()
		{
			this.m_Head = (this.m_Tail = 0);
			Array.Clear(this.m_Buffer, 0, this.m_Buffer.Length);
		}

		// Token: 0x040009DB RID: 2523
		public readonly int DEFAULTSOCKETOUTPUTBUFFERSIZE = 1048576;

		// Token: 0x040009DC RID: 2524
		public int m_BufferLen;

		// Token: 0x040009DD RID: 2525
		public int m_MaxBufferLen;

		// Token: 0x040009DE RID: 2526
		public byte[] m_Buffer;

		// Token: 0x040009DF RID: 2527
		public int m_Head;

		// Token: 0x040009E0 RID: 2528
		public int m_Tail;
	}
}
