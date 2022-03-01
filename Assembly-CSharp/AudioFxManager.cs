using System;
using System.Collections;
using GameClient;
using UnityEngine;

// Token: 0x0200454B RID: 17739
internal class AudioFxManager : MonoSingleton<AudioFxManager>
{
	// Token: 0x1700201F RID: 8223
	// (get) Token: 0x06018B1C RID: 101148 RVA: 0x007B7508 File Offset: 0x007B5908
	// (set) Token: 0x06018B1D RID: 101149 RVA: 0x007B751F File Offset: 0x007B591F
	public float Volume
	{
		get
		{
			return (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
		}
		set
		{
			DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume = (double)value;
			if (this.soundManger != null)
			{
				this.soundManger.volume = value;
			}
		}
	}

	// Token: 0x17002020 RID: 8224
	// (get) Token: 0x06018B1E RID: 101150 RVA: 0x007B7554 File Offset: 0x007B5954
	// (set) Token: 0x06018B1F RID: 101151 RVA: 0x007B756A File Offset: 0x007B596A
	public bool Mute
	{
		get
		{
			return DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute;
		}
		set
		{
			DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute = value;
			if (this.soundManger != null)
			{
				this.soundManger.mute = value;
			}
		}
	}

	// Token: 0x06018B20 RID: 101152 RVA: 0x007B75A0 File Offset: 0x007B59A0
	public override void Init()
	{
		GameObject gameObject = Utility.FindGameObject("Environment/AudioManager/Sfx", true);
		if (gameObject)
		{
			this.soundManger = gameObject.GetComponent<AudioSource>();
		}
	}

	// Token: 0x06018B21 RID: 101153 RVA: 0x007B75D0 File Offset: 0x007B59D0
	public void PlaySound(AudioClip clip, float volumeScale, bool shot, float pitch, bool loop = false)
	{
		if (this.soundManger != null)
		{
			this.soundManger.pitch = pitch;
			this.soundManger.loop = loop;
			this.soundManger.PlayOneShot(clip, volumeScale);
		}
	}

	// Token: 0x06018B22 RID: 101154 RVA: 0x007B760A File Offset: 0x007B5A0A
	public void Stop()
	{
		if (this.soundManger != null)
		{
			this.soundManger.Stop();
		}
	}

	// Token: 0x06018B23 RID: 101155 RVA: 0x007B7628 File Offset: 0x007B5A28
	private IEnumerator AysncPlaySound(Object go, string path = null, float volumeScale = 1f, bool shot = true, float pitch = 1f, bool bloop = false)
	{
		string nepath = CFileManager.EraseExtension(path);
		AssetInst rt = Singleton<AssetLoader>.instance.LoadRes(nepath, true, 0U);
		yield return rt;
		go = rt.obj;
		if (go != null)
		{
			this.PlaySound((AudioClip)go, volumeScale, shot, pitch, bloop);
		}
		yield break;
	}

	// Token: 0x06018B24 RID: 101156 RVA: 0x007B7670 File Offset: 0x007B5A70
	public void PlaySFX(Object go, string path = null, float volumeScale = 1f, bool shot = true, float pitch = 1f, bool bloop = false)
	{
		if (go == null && path == null)
		{
			return;
		}
		if (path != null)
		{
			base.StartCoroutine(this.AysncPlaySound(null, path, volumeScale, shot, pitch, bloop));
		}
		if (go != null)
		{
			this.PlaySound((AudioClip)go, volumeScale, shot, pitch, bloop);
		}
	}

	// Token: 0x04011CC8 RID: 72904
	protected AudioSource soundManger;
}
