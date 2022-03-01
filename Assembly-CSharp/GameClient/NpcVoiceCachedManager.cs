using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004611 RID: 17937
	internal class NpcVoiceCachedManager : Singleton<NpcVoiceCachedManager>
	{
		// Token: 0x170020B6 RID: 8374
		// (get) Token: 0x0601937D RID: 103293 RVA: 0x007FA3DB File Offset: 0x007F87DB
		// (set) Token: 0x0601937E RID: 103294 RVA: 0x007FA3E3 File Offset: 0x007F87E3
		public float Volume
		{
			get
			{
				return this.fVolume;
			}
			set
			{
				this.fVolume = value;
			}
		}

		// Token: 0x0601937F RID: 103295 RVA: 0x007FA3EC File Offset: 0x007F87EC
		public void SetMute(bool bMute)
		{
			this.audioSource.mute = bMute;
		}

		// Token: 0x06019380 RID: 103296 RVA: 0x007FA3FA File Offset: 0x007F87FA
		public void SetVolume(float fVolume)
		{
			this.fVolume = fVolume;
		}

		// Token: 0x06019381 RID: 103297 RVA: 0x007FA404 File Offset: 0x007F8804
		public bool PlaySound(string path, float volume = 1f)
		{
			if (this.audioManager == null)
			{
				this.audioManager = GameObject.Find("Environment").transform.Find("AudioManager").Find("NpcSfx").gameObject;
				if (this.audioManager != null)
				{
					this.audioSource = this.audioManager.GetComponent<AudioSource>();
				}
			}
			if (this.audioSource == null)
			{
				return false;
			}
			this.audioSource.volume = this.fVolume * volume;
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null || clientSystemTown.MainPlayer == null)
			{
				return false;
			}
			if (this.audioSource.isPlaying)
			{
				this.audioSource.Stop();
			}
			AudioClip audioClip = Singleton<AssetLoader>.instance.LoadRes(path, typeof(AudioClip), true, 0U).obj as AudioClip;
			if (audioClip == null)
			{
				return false;
			}
			this.audioSource.PlayOneShot(audioClip, volume);
			return true;
		}

		// Token: 0x0401211C RID: 74012
		protected AudioSource audioSource;

		// Token: 0x0401211D RID: 74013
		protected GameObject audioManager;

		// Token: 0x0401211E RID: 74014
		protected float fMaxSoundDistance = 7f;

		// Token: 0x0401211F RID: 74015
		protected float fVolume = 1f;

		// Token: 0x04012120 RID: 74016
		protected bool bInit;
	}
}
