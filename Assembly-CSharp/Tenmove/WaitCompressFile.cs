using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameClient;
using LibZip;

namespace Tenmove
{
	// Token: 0x020001AC RID: 428
	public class WaitCompressFile : BaseCustomEnum<WaitCompressFile.State>, IEnumerator
	{
		// Token: 0x06000DD9 RID: 3545 RVA: 0x00047E03 File Offset: 0x00046203
		public WaitCompressFile(string target, string root, string[] files)
		{
			this.ZipFilePath = target;
			this.FilesRoot = root;
			this.mFiles = files;
			this._StartProgress();
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00047E32 File Offset: 0x00046232
		public WaitCompressFile(string target, string root, string searchOption)
		{
			this.ZipFilePath = target;
			this.FilesRoot = root;
			this.mFiles = TMFile.GetFiles(root, searchOption, true);
			this._StartProgress();
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00047E68 File Offset: 0x00046268
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x00047E70 File Offset: 0x00046270
		public string FilesRoot { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00047E79 File Offset: 0x00046279
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00047E81 File Offset: 0x00046281
		public string ZipFilePath { get; set; }

		// Token: 0x06000DDF RID: 3551 RVA: 0x00047E8C File Offset: 0x0004628C
		private bool _StartProgress()
		{
			if (this.mFiles == null || this.mFiles.Count == 0)
			{
				Logger.LogErrorFormat("[Zip] CompressFiles file list is empty", new object[0]);
				base.SetResult(WaitCompressFile.State.Error);
				return false;
			}
			TMPathUtil.MakeParentRootExist(this.ZipFilePath);
			this.mCurrentFileIdx = 0;
			this._OpenZipFile();
			base.SetResult(WaitCompressFile.State.Progress);
			return true;
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x00047EED File Offset: 0x000462ED
		public object Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00047EF0 File Offset: 0x000462F0
		private int FileCounts
		{
			get
			{
				if (this.mFiles == null)
				{
					return 1;
				}
				return this.mFiles.Count;
			}
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00047F0A File Offset: 0x0004630A
		private void _OpenZipFile()
		{
			this.mZipFilePtr = LibZip.zip_open(this.ZipFilePath, 1, IntPtr.Zero);
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00047F23 File Offset: 0x00046323
		private void _CloseZipFile()
		{
			if (IntPtr.Zero != this.mZipFilePtr)
			{
				LibZip.zip_close(this.mZipFilePtr);
			}
			this.mZipFilePtr = IntPtr.Zero;
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00047F54 File Offset: 0x00046354
		public bool MoveNext()
		{
			switch (base.GetResult())
			{
			case WaitCompressFile.State.None:
				this._OpenZipFile();
				base.SetResult(WaitCompressFile.State.Progress);
				break;
			case WaitCompressFile.State.Progress:
				if (this.mCurrentFileIdx >= this.FileCounts)
				{
					base.SetResult(WaitCompressFile.State.Finish);
				}
				else
				{
					string text = this.mFiles[this.mCurrentFileIdx];
					if (!TMZipFile.WriteOneFile2ZipSource(this.mZipFilePtr, this.FilesRoot, text))
					{
						Logger.LogErrorFormat("[Zip] CompressFiles Open File fail {0}", new object[]
						{
							text
						});
					}
					this.mCurrentFileIdx++;
				}
				break;
			case WaitCompressFile.State.Finish:
			case WaitCompressFile.State.Error:
				this._CloseZipFile();
				return false;
			}
			return true;
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x0004800B File Offset: 0x0004640B
		public void Reset()
		{
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00048010 File Offset: 0x00046410
		public void DeleteCompressedFiles()
		{
			for (int i = 0; i < this.mFiles.Count; i++)
			{
				try
				{
					File.Delete(this.mFiles[i]);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat(ex.ToString(), new object[0]);
				}
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00048078 File Offset: 0x00046478
		public bool IsSuccessFinish()
		{
			return base.GetResult() == WaitCompressFile.State.Finish && TMFile.FileExist(this.ZipFilePath);
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x0004809B File Offset: 0x0004649B
		public void Abort()
		{
			if (base.GetResult() == WaitCompressFile.State.Progress)
			{
				this._CloseZipFile();
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x000480B0 File Offset: 0x000464B0
		public float Rate
		{
			get
			{
				WaitCompressFile.State result = base.GetResult();
				if (result == WaitCompressFile.State.Progress)
				{
					return 1f * (float)this.mCurrentFileIdx / (float)this.FileCounts;
				}
				if (result != WaitCompressFile.State.Error && result != WaitCompressFile.State.Finish)
				{
					return 0f;
				}
				return 1f;
			}
		}

		// Token: 0x040009A9 RID: 2473
		private IList<string> mFiles;

		// Token: 0x040009AA RID: 2474
		private IntPtr mZipFilePtr = IntPtr.Zero;

		// Token: 0x040009AB RID: 2475
		private int mCurrentFileIdx;

		// Token: 0x020001AD RID: 429
		public enum State
		{
			// Token: 0x040009AD RID: 2477
			None,
			// Token: 0x040009AE RID: 2478
			Progress,
			// Token: 0x040009AF RID: 2479
			Finish,
			// Token: 0x040009B0 RID: 2480
			Error
		}
	}
}
