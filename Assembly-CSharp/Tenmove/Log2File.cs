using System;
using System.IO;

namespace Tenmove
{
	// Token: 0x020046B0 RID: 18096
	public class Log2File
	{
		// Token: 0x06019A3B RID: 105019 RVA: 0x00812F80 File Offset: 0x00811380
		public Log2File()
		{
			this.m_Stream = new FileStream(Log2File.Path, FileMode.Append, FileAccess.Write);
			if (this.m_Stream != null)
			{
				this.m_Writer = new StreamWriter(this.m_Stream);
				this.m_Writer.WriteLine(" ");
				this.m_Writer.WriteLine(" ");
				this.m_Writer.WriteLine(string.Format("############################### Log2File Online:{0} ###############################", DateTime.Now.ToString("yyyy-MM-dd")));
				this.m_Writer.WriteLine(" ");
				this.m_Writer.WriteLine(" ");
			}
		}

		// Token: 0x06019A3C RID: 105020 RVA: 0x00813028 File Offset: 0x00811428
		~Log2File()
		{
			this._Close();
		}

		// Token: 0x17002130 RID: 8496
		// (get) Token: 0x06019A3D RID: 105021 RVA: 0x00813058 File Offset: 0x00811458
		private static Log2File Instance
		{
			get
			{
				if (Log2File.sm_Instance == null && !string.IsNullOrEmpty(Log2File.Path))
				{
					Log2File.sm_Instance = new Log2File();
				}
				return Log2File.sm_Instance;
			}
		}

		// Token: 0x06019A3E RID: 105022 RVA: 0x00813084 File Offset: 0x00811484
		public static void Log(string fmt, params object[] args)
		{
			Log2File instance = Log2File.Instance;
			if (instance != null)
			{
				instance._Log(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), string.Format(fmt, args)));
			}
		}

		// Token: 0x06019A3F RID: 105023 RVA: 0x008130C8 File Offset: 0x008114C8
		public static void Log(string content)
		{
			Log2File instance = Log2File.Instance;
			if (instance != null)
			{
				instance._Log(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), content));
			}
		}

		// Token: 0x06019A40 RID: 105024 RVA: 0x00813104 File Offset: 0x00811504
		public static void Close()
		{
			if (Log2File.sm_Instance != null)
			{
				Log2File.sm_Instance._Close();
			}
		}

		// Token: 0x06019A41 RID: 105025 RVA: 0x0081311A File Offset: 0x0081151A
		private void _Log(string content)
		{
			if (this.m_Writer != null)
			{
				this.m_Writer.WriteLine(content);
				this.m_Writer.Flush();
				if (this.m_Stream != null)
				{
					this.m_Stream.Flush();
				}
			}
		}

		// Token: 0x06019A42 RID: 105026 RVA: 0x00813154 File Offset: 0x00811554
		private void _Close()
		{
			if (this.m_Writer != null)
			{
				this.m_Writer.Close();
				this.m_Writer = null;
			}
			if (this.m_Stream != null)
			{
				this.m_Stream.Close();
				this.m_Stream = null;
			}
			Log2File.sm_Instance = null;
		}

		// Token: 0x0401245F RID: 74847
		private static Log2File sm_Instance;

		// Token: 0x04012460 RID: 74848
		public static string Path;

		// Token: 0x04012461 RID: 74849
		private Stream m_Stream;

		// Token: 0x04012462 RID: 74850
		private StreamWriter m_Writer;
	}
}
