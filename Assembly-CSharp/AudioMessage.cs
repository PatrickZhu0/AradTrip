using System;
using UnityEngine;
using YIMEngine;
using YouMe;

// Token: 0x02004AB7 RID: 19127
public class AudioMessage : IMMessage
{
	// Token: 0x0601BC2E RID: 113710 RVA: 0x008831F8 File Offset: 0x008815F8
	public AudioMessage(string sender, string reciverID, ChatType chatType, string extraParam, bool isFromServer)
	{
		base.SenderID = sender;
		base.MessageType = MessageBodyType.Voice;
		base.ReciverID = reciverID;
		base.ChatType = chatType;
		this.extraParam = extraParam;
		base.IsReceiveFromServer = isFromServer;
		if (isFromServer)
		{
			base.SendStatus = SendStatus.Sended;
		}
		else
		{
			base.SendStatus = SendStatus.NotStartSend;
		}
	}

	// Token: 0x17002573 RID: 9587
	// (get) Token: 0x0601BC2F RID: 113711 RVA: 0x00883251 File Offset: 0x00881651
	public string ExtraParam
	{
		get
		{
			return this.extraParam;
		}
	}

	// Token: 0x17002574 RID: 9588
	// (get) Token: 0x0601BC31 RID: 113713 RVA: 0x00883262 File Offset: 0x00881662
	// (set) Token: 0x0601BC30 RID: 113712 RVA: 0x00883259 File Offset: 0x00881659
	public MessageDownloadStatus MessageDownloadStatus
	{
		get
		{
			return this.downloadStatus;
		}
		set
		{
			this.downloadStatus = value;
		}
	}

	// Token: 0x17002575 RID: 9589
	// (get) Token: 0x0601BC33 RID: 113715 RVA: 0x00883273 File Offset: 0x00881673
	// (set) Token: 0x0601BC32 RID: 113714 RVA: 0x0088326A File Offset: 0x0088166A
	public string AudioFilePath
	{
		get
		{
			return this.audioFilePath;
		}
		set
		{
			this.audioFilePath = value;
		}
	}

	// Token: 0x17002576 RID: 9590
	// (get) Token: 0x0601BC35 RID: 113717 RVA: 0x00883284 File Offset: 0x00881684
	// (set) Token: 0x0601BC34 RID: 113716 RVA: 0x0088327B File Offset: 0x0088167B
	public string RecongnizeText
	{
		get
		{
			return this.recognizedText;
		}
		set
		{
			this.recognizedText = value;
		}
	}

	// Token: 0x17002577 RID: 9591
	// (get) Token: 0x0601BC37 RID: 113719 RVA: 0x00883295 File Offset: 0x00881695
	// (set) Token: 0x0601BC36 RID: 113718 RVA: 0x0088328C File Offset: 0x0088168C
	public int AudioDuration
	{
		get
		{
			return this.audioDuration;
		}
		set
		{
			this.audioDuration = value;
		}
	}

	// Token: 0x0601BC38 RID: 113720 RVA: 0x008832A0 File Offset: 0x008816A0
	public void PlayAudio(Action<StatusCode, string> playCallback, float volume = 1f)
	{
		if (!string.IsNullOrEmpty(this.audioFilePath))
		{
			IMClient.Instance.StartPlayAudio(this.audioFilePath, delegate(StatusCode code, string filePath)
			{
				playCallback(code, filePath);
			}, volume);
		}
		else
		{
			playCallback(StatusCode.Fail, string.Empty);
		}
	}

	// Token: 0x0601BC39 RID: 113721 RVA: 0x00883301 File Offset: 0x00881701
	public StatusCode StopPlay()
	{
		return IMClient.Instance.StopPlayAudio();
	}

	// Token: 0x0601BC3A RID: 113722 RVA: 0x0088330D File Offset: 0x0088170D
	public void PlayInQueue()
	{
	}

	// Token: 0x0601BC3B RID: 113723 RVA: 0x00883310 File Offset: 0x00881710
	public void Download(Action<StatusCode, AudioMessage> downloadCallback, string targetPath = "")
	{
		if (!base.IsReceiveFromServer)
		{
			Log.e("只能下载从服务器收到的语音消息，自己发送的语音消息不需要下载。");
			return;
		}
		if (this.downloadStatus == MessageDownloadStatus.DOWNLOADED)
		{
			if (downloadCallback != null)
			{
				downloadCallback(StatusCode.Success, this);
			}
			return;
		}
		this.downloadStatus = MessageDownloadStatus.DOWNLOADING;
		string uniqAudioPath = this.GetUniqAudioPath();
		if (IMClient.Instance._downloadDirPath == string.Empty && targetPath == string.Empty)
		{
			targetPath = uniqAudioPath;
		}
		IMClient.Instance.DownloadFile(base.RequestID, targetPath, delegate(StatusCode code, IMMessage messageObj, string savePath)
		{
			if (code == StatusCode.Success)
			{
				this.downloadStatus = MessageDownloadStatus.DOWNLOADED;
			}
			else
			{
				this.downloadStatus = MessageDownloadStatus.DOWNLOAD_FAIL;
			}
			this.audioFilePath = savePath;
			if (downloadCallback != null)
			{
				downloadCallback(code, this);
			}
		});
	}

	// Token: 0x0601BC3C RID: 113724 RVA: 0x008833C3 File Offset: 0x008817C3
	public string GetUniqAudioPath()
	{
		return string.Concat(new object[]
		{
			Application.temporaryCachePath,
			"/YoumeIMAudioCache/",
			base.RequestID,
			".wav"
		});
	}

	// Token: 0x040135B0 RID: 79280
	private MessageDownloadStatus downloadStatus;

	// Token: 0x040135B1 RID: 79281
	private string audioFilePath;

	// Token: 0x040135B2 RID: 79282
	private string recognizedText;

	// Token: 0x040135B3 RID: 79283
	private string extraParam;

	// Token: 0x040135B4 RID: 79284
	private int audioDuration;
}
