using System;

// Token: 0x02004ABC RID: 19132
public class SpeechInfo
{
	// Token: 0x0601BC4F RID: 113743 RVA: 0x00883668 File Offset: 0x00881A68
	public SpeechInfo(ulong requestID)
	{
		this._requestID = requestID;
	}

	// Token: 0x17002583 RID: 9603
	// (get) Token: 0x0601BC50 RID: 113744 RVA: 0x00883677 File Offset: 0x00881A77
	public ulong RequestID
	{
		get
		{
			return this._requestID;
		}
	}

	// Token: 0x17002584 RID: 9604
	// (get) Token: 0x0601BC52 RID: 113746 RVA: 0x00883688 File Offset: 0x00881A88
	// (set) Token: 0x0601BC51 RID: 113745 RVA: 0x0088367F File Offset: 0x00881A7F
	public string DownloadURL
	{
		get
		{
			return this._downloadURL;
		}
		set
		{
			this._downloadURL = value;
		}
	}

	// Token: 0x17002585 RID: 9605
	// (get) Token: 0x0601BC54 RID: 113748 RVA: 0x00883699 File Offset: 0x00881A99
	// (set) Token: 0x0601BC53 RID: 113747 RVA: 0x00883690 File Offset: 0x00881A90
	public int Duration
	{
		get
		{
			return this._duration;
		}
		set
		{
			this._duration = value;
		}
	}

	// Token: 0x17002586 RID: 9606
	// (get) Token: 0x0601BC56 RID: 113750 RVA: 0x008836AA File Offset: 0x00881AAA
	// (set) Token: 0x0601BC55 RID: 113749 RVA: 0x008836A1 File Offset: 0x00881AA1
	public int FileSize
	{
		get
		{
			return this._fileSize;
		}
		set
		{
			this._fileSize = value;
		}
	}

	// Token: 0x17002587 RID: 9607
	// (get) Token: 0x0601BC58 RID: 113752 RVA: 0x008836BB File Offset: 0x00881ABB
	// (set) Token: 0x0601BC57 RID: 113751 RVA: 0x008836B2 File Offset: 0x00881AB2
	public string LocalPath
	{
		get
		{
			return this._localPath;
		}
		set
		{
			this._localPath = value;
		}
	}

	// Token: 0x17002588 RID: 9608
	// (get) Token: 0x0601BC5A RID: 113754 RVA: 0x008836CC File Offset: 0x00881ACC
	// (set) Token: 0x0601BC59 RID: 113753 RVA: 0x008836C3 File Offset: 0x00881AC3
	public string Text
	{
		get
		{
			return this._text;
		}
		set
		{
			this._text = value;
		}
	}

	// Token: 0x17002589 RID: 9609
	// (get) Token: 0x0601BC5C RID: 113756 RVA: 0x008836DD File Offset: 0x00881ADD
	// (set) Token: 0x0601BC5B RID: 113755 RVA: 0x008836D4 File Offset: 0x00881AD4
	public bool HasUpload
	{
		get
		{
			return this._hasUpload;
		}
		set
		{
			this._hasUpload = value;
		}
	}

	// Token: 0x040135BF RID: 79295
	private ulong _requestID;

	// Token: 0x040135C0 RID: 79296
	private string _downloadURL;

	// Token: 0x040135C1 RID: 79297
	private int _duration;

	// Token: 0x040135C2 RID: 79298
	private int _fileSize;

	// Token: 0x040135C3 RID: 79299
	private string _localPath;

	// Token: 0x040135C4 RID: 79300
	private string _text;

	// Token: 0x040135C5 RID: 79301
	private bool _hasUpload;
}
