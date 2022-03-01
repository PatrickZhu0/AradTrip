using System;
using System.IO;

// Token: 0x020001B4 RID: 436
public class MapViewStream
{
	// Token: 0x06000E03 RID: 3587 RVA: 0x00048780 File Offset: 0x00046B80
	public MapViewStream(string fileName, byte[] buffer, MapViewStream.FileAccessMode eMode, int fileOffset = 0)
	{
		if (buffer == null)
		{
			throw new Exception("MapViewStream buffer can not be empty!");
		}
		this.mFileName = fileName;
		this.mBuffer = buffer;
		this.mOpenMode = eMode;
		this.mCurFileOffset = fileOffset;
		if (this.mOpenMode == MapViewStream.FileAccessMode.Read)
		{
			if (!this._FlushToBuffer())
			{
				throw new Exception("first _FlushToFile occur error");
			}
		}
		else if (fileOffset == 0 && File.Exists(this.mFileName))
		{
			File.Delete(this.mFileName);
		}
	}

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0004881C File Offset: 0x00046C1C
	public int Length
	{
		get
		{
			return 0;
		}
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x00048820 File Offset: 0x00046C20
	private bool _FlushToFile()
	{
		if (this.mFileName.Equals(string.Empty))
		{
			return false;
		}
		FileStream fileStream = null;
		BinaryWriter binaryWriter = null;
		try
		{
			if (!File.Exists(this.mFileName))
			{
				fileStream = new FileStream(this.mFileName, FileMode.Create, FileAccess.Write);
			}
			else
			{
				fileStream = new FileStream(this.mFileName, FileMode.Append, FileAccess.Write);
			}
			binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.Seek(0, SeekOrigin.End);
			binaryWriter.Write(this.mBuffer, 0, this.mCurUsedMemoCount);
			binaryWriter.Flush();
			binaryWriter.Close();
			fileStream.Close();
			this.mCurFileOffset += this.mCurUsedMemoCount;
			this.mCurUsedMemoCount = 0;
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("_FlushToFile Failed {0}", new object[]
			{
				ex.ToString()
			});
			if (binaryWriter != null)
			{
				binaryWriter.Close();
				binaryWriter = null;
			}
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream = null;
			}
			return false;
		}
		return true;
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x00048920 File Offset: 0x00046D20
	private bool _FlushToBuffer()
	{
		if (this.mFileName.Equals(string.Empty))
		{
			return false;
		}
		if (!File.Exists(this.mFileName))
		{
			return false;
		}
		FileStream fileStream = new FileStream(this.mFileName, FileMode.Open, FileAccess.Read);
		if ((long)this.mCurFileOffset >= fileStream.Length)
		{
			fileStream.Close();
			return false;
		}
		BinaryReader binaryReader = new BinaryReader(fileStream);
		binaryReader.BaseStream.Seek((long)this.mCurFileOffset, SeekOrigin.Begin);
		long num = fileStream.Length - (long)this.mCurFileOffset;
		int num2 = this.mBuffer.Length;
		Array.Clear(this.mBuffer, 0, num2);
		if ((long)num2 >= num)
		{
			binaryReader.Read(this.mBuffer, 0, (int)num);
			this.mCurFileOffset += (int)num;
		}
		else
		{
			binaryReader.Read(this.mBuffer, 0, num2);
			this.mCurFileOffset += num2;
		}
		binaryReader.Close();
		fileStream.Close();
		this.mCurUsedMemoCount = 0;
		return true;
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x00048A20 File Offset: 0x00046E20
	public bool write(byte value)
	{
		bool flag = true;
		if (this.mCurUsedMemoCount >= this.mBuffer.Length)
		{
			flag = this._FlushToFile();
		}
		if (!flag)
		{
			return false;
		}
		this.mBuffer[this.mCurUsedMemoCount] = value;
		this.mCurUsedMemoCount++;
		return true;
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x00048A70 File Offset: 0x00046E70
	public bool read(ref byte value)
	{
		bool flag = true;
		if (this.mCurUsedMemoCount >= this.mBuffer.Length)
		{
			flag = this._FlushToBuffer();
		}
		if (!flag)
		{
			throw new Exception("_FlushToBuffer occur error");
		}
		value = this.mBuffer[this.mCurUsedMemoCount];
		this.mCurUsedMemoCount++;
		return true;
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x00048AC8 File Offset: 0x00046EC8
	public bool encode_int8(byte val)
	{
		return this.write(val);
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x00048AD1 File Offset: 0x00046ED1
	public bool decode_int8(ref byte val)
	{
		return this.read(ref val);
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x00048ADC File Offset: 0x00046EDC
	public bool encode_uint16(ushort val)
	{
		bool flag = this.write((byte)(val & 255));
		return flag & this.write((byte)(val >> 8 & 255));
	}

	// Token: 0x06000E0C RID: 3596 RVA: 0x00048B10 File Offset: 0x00046F10
	public bool decode_uint16(ref ushort val)
	{
		bool flag = true;
		val = 0;
		ushort num = 0;
		byte b = 0;
		for (int i = 0; i < 2; i++)
		{
			flag &= this.read(ref b);
			ushort num2 = (ushort)b;
			val |= (ushort)(num2 << (int)num);
			num += 8;
		}
		return flag;
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x00048B5A File Offset: 0x00046F5A
	public bool encode_int16(short val)
	{
		return this.encode_uint16((ushort)val);
	}

	// Token: 0x06000E0E RID: 3598 RVA: 0x00048B64 File Offset: 0x00046F64
	public bool decode_int16(ref short val)
	{
		ushort num = 0;
		bool result = this.decode_uint16(ref num);
		val = (short)num;
		return result;
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x00048B84 File Offset: 0x00046F84
	public bool encode_uint32(uint val)
	{
		bool flag = true;
		for (int i = 0; i < 4; i++)
		{
			flag &= this.write((byte)(val & 255U));
			val >>= 8;
		}
		return flag;
	}

	// Token: 0x06000E10 RID: 3600 RVA: 0x00048BBC File Offset: 0x00046FBC
	public bool decode_uint32(ref uint val)
	{
		val = 0U;
		int num = 0;
		byte b = 0;
		bool flag = true;
		for (int i = 0; i < 4; i++)
		{
			flag &= this.read(ref b);
			uint num2 = (uint)b;
			val |= num2 << num;
			num += 8;
		}
		return flag;
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x00048C05 File Offset: 0x00047005
	public bool encode_int32(int val)
	{
		return this.encode_uint32((uint)val);
	}

	// Token: 0x06000E12 RID: 3602 RVA: 0x00048C10 File Offset: 0x00047010
	public bool decode_int32(ref int val)
	{
		uint num = 0U;
		bool result = this.decode_uint32(ref num);
		val = (int)num;
		return result;
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x00048C2C File Offset: 0x0004702C
	public bool encode_uint64(ulong val)
	{
		bool flag = true;
		for (int i = 0; i < 8; i++)
		{
			flag &= this.write((byte)(val & 255UL));
			val >>= 8;
		}
		return flag;
	}

	// Token: 0x06000E14 RID: 3604 RVA: 0x00048C68 File Offset: 0x00047068
	public bool decode_uint64(ref ulong val)
	{
		val = 0UL;
		int num = 0;
		byte b = 0;
		bool result = true;
		for (int i = 0; i < 8; i++)
		{
			result = this.read(ref b);
			ulong num2 = (ulong)b;
			val |= num2 << num;
			num += 8;
		}
		return result;
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x00048CAF File Offset: 0x000470AF
	public bool encode_int64(long val)
	{
		return this.encode_uint64((ulong)val);
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x00048CB8 File Offset: 0x000470B8
	public bool decode_int64(ref long val)
	{
		ulong num = 0UL;
		bool result = this.decode_uint64(ref num);
		val = (long)num;
		return result;
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x00048CD8 File Offset: 0x000470D8
	public bool encode_string(string str)
	{
		byte[] array = StringHelper.StringToUTF8Bytes(str);
		ushort num = 0;
		if (array != null && array.Length > 0)
		{
			num = (ushort)(array.Length - 1);
		}
		bool flag = this.encode_uint16(num);
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			flag &= this.encode_int8(array[(int)num2]);
		}
		return flag;
	}

	// Token: 0x06000E18 RID: 3608 RVA: 0x00048D30 File Offset: 0x00047130
	public bool encode_string(byte[] buffer)
	{
		ushort num = 0;
		if (buffer != null && buffer.Length > 0)
		{
			num = (ushort)(buffer.Length - 1);
		}
		bool flag = this.encode_uint16(num);
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			flag &= this.encode_int8(buffer[(int)num2]);
		}
		return flag;
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x00048D80 File Offset: 0x00047180
	public bool decode_string(ref string str)
	{
		ushort num = 0;
		bool flag = this.decode_uint16(ref num);
		byte[] array = new byte[(int)num];
		byte b = 0;
		for (int i = 0; i < (int)num; i++)
		{
			flag &= this.decode_int8(ref b);
			array[i] = b;
		}
		str = StringHelper.UTF8BytesToString(ref array);
		return flag;
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x00048DD4 File Offset: 0x000471D4
	public bool decode_string(byte[] buffer)
	{
		ushort num = 0;
		bool flag = this.decode_uint16(ref num);
		buffer = new byte[(int)num];
		byte b = 0;
		for (int i = 0; i < (int)num; i++)
		{
			flag &= this.decode_int8(ref b);
			buffer[i] = b;
		}
		return flag;
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x00048E18 File Offset: 0x00047218
	public bool Save()
	{
		if (this.mOpenMode != MapViewStream.FileAccessMode.Write)
		{
			return false;
		}
		if (this.mCurUsedMemoCount <= 0)
		{
			return false;
		}
		FileStream fileStream = null;
		BinaryWriter binaryWriter = null;
		bool result;
		try
		{
			if (!File.Exists(this.mFileName))
			{
				fileStream = new FileStream(this.mFileName, FileMode.Create, FileAccess.Write);
			}
			else
			{
				fileStream = new FileStream(this.mFileName, FileMode.Append, FileAccess.Write);
			}
			binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.Seek(this.mCurFileOffset, SeekOrigin.Begin);
			binaryWriter.Write(this.mBuffer, 0, this.mCurUsedMemoCount);
			binaryWriter.Flush();
			binaryWriter.Close();
			fileStream.Close();
			result = true;
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[MapViewStream] save file failed Exception {0}", new object[]
			{
				ex.Message
			});
			if (binaryWriter != null)
			{
				binaryWriter.Close();
				binaryWriter = null;
			}
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream = null;
			}
			result = false;
		}
		return result;
	}

	// Token: 0x040009C3 RID: 2499
	private byte[] mBuffer;

	// Token: 0x040009C4 RID: 2500
	private int mCurFileOffset;

	// Token: 0x040009C5 RID: 2501
	private int mCurUsedMemoCount;

	// Token: 0x040009C6 RID: 2502
	private string mFileName = string.Empty;

	// Token: 0x040009C7 RID: 2503
	private MapViewStream.FileAccessMode mOpenMode = MapViewStream.FileAccessMode.NONE;

	// Token: 0x020001B5 RID: 437
	public enum FileAccessMode
	{
		// Token: 0x040009C9 RID: 2505
		Write,
		// Token: 0x040009CA RID: 2506
		Read,
		// Token: 0x040009CB RID: 2507
		NONE
	}
}
