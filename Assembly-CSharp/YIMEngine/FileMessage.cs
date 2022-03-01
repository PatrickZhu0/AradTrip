using System;

namespace YIMEngine
{
	// Token: 0x02004A52 RID: 19026
	public class FileMessage : MessageInfoBase
	{
		// Token: 0x17002495 RID: 9365
		// (get) Token: 0x0601B8E8 RID: 112872 RVA: 0x0087B3BB File Offset: 0x008797BB
		// (set) Token: 0x0601B8E9 RID: 112873 RVA: 0x0087B3C3 File Offset: 0x008797C3
		public string ExtParam
		{
			get
			{
				return this.strExtParam;
			}
			set
			{
				this.strExtParam = value;
			}
		}

		// Token: 0x17002496 RID: 9366
		// (get) Token: 0x0601B8EA RID: 112874 RVA: 0x0087B3CC File Offset: 0x008797CC
		// (set) Token: 0x0601B8EB RID: 112875 RVA: 0x0087B3D4 File Offset: 0x008797D4
		public string FileExtension
		{
			get
			{
				return this.strExtension;
			}
			set
			{
				this.strExtension = value;
			}
		}

		// Token: 0x17002497 RID: 9367
		// (get) Token: 0x0601B8EC RID: 112876 RVA: 0x0087B3DD File Offset: 0x008797DD
		// (set) Token: 0x0601B8ED RID: 112877 RVA: 0x0087B3E5 File Offset: 0x008797E5
		public string FileName
		{
			get
			{
				return this.strFileName;
			}
			set
			{
				this.strFileName = value;
			}
		}

		// Token: 0x17002498 RID: 9368
		// (get) Token: 0x0601B8EE RID: 112878 RVA: 0x0087B3EE File Offset: 0x008797EE
		// (set) Token: 0x0601B8EF RID: 112879 RVA: 0x0087B3F6 File Offset: 0x008797F6
		public int FileSize
		{
			get
			{
				return this.iFileSize;
			}
			set
			{
				this.iFileSize = value;
			}
		}

		// Token: 0x17002499 RID: 9369
		// (get) Token: 0x0601B8F0 RID: 112880 RVA: 0x0087B3FF File Offset: 0x008797FF
		// (set) Token: 0x0601B8F1 RID: 112881 RVA: 0x0087B407 File Offset: 0x00879807
		public FileType FileType
		{
			get
			{
				return this.fFileType;
			}
			set
			{
				this.fFileType = value;
			}
		}

		// Token: 0x0401320F RID: 78351
		private string strFileName;

		// Token: 0x04013210 RID: 78352
		private int iFileSize;

		// Token: 0x04013211 RID: 78353
		private FileType fFileType;

		// Token: 0x04013212 RID: 78354
		private string strExtension;

		// Token: 0x04013213 RID: 78355
		private string strExtParam;
	}
}
