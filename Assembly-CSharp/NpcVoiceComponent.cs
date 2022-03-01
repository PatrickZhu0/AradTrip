using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004612 RID: 17938
public class NpcVoiceComponent : MonoBehaviour
{
	// Token: 0x06019383 RID: 103299 RVA: 0x007FA548 File Offset: 0x007F8948
	public void Initialize(int iNpcID)
	{
		this.iNpcID = iNpcID;
		this.fInterval = float.PositiveInfinity;
		this.npcItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
		if (this.npcItem != null)
		{
			this.akSoundEffectsArray[0] = this.npcItem.SEStand;
			this.akSoundEffectsArray[1] = this.npcItem.SEStart;
			this.akSoundEffectsArray[2] = this.npcItem.SEEnd;
			this.fInterval = (float)this.npcItem.SEPeriod;
		}
		this.eSoundEffectType = NpcVoiceComponent.SoundEffectType.SET_INVALID;
	}

	// Token: 0x06019384 RID: 103300 RVA: 0x007FA5E0 File Offset: 0x007F89E0
	public void PlaySound(NpcVoiceComponent.SoundEffectType eSoundEffectType)
	{
		this.eSoundEffectType = eSoundEffectType;
		if (this.npcItem != null && eSoundEffectType != NpcVoiceComponent.SoundEffectType.SET_INVALID && eSoundEffectType >= NpcVoiceComponent.SoundEffectType.SET_Random && eSoundEffectType <= NpcVoiceComponent.SoundEffectType.SET_End)
		{
			IList<string> list = this.akSoundEffectsArray[(int)eSoundEffectType];
			if (list != null && list.Count > 0)
			{
				int index = Random.Range(0, list.Count - 1);
				if (this.audioHandle != 4294967295U)
				{
					MonoSingleton<AudioManager>.instance.Stop(this.audioHandle);
				}
				this.audioHandle = uint.MaxValue;
				if (list.Count > 0 && !string.IsNullOrEmpty(list[index]))
				{
					this.audioHandle = MonoSingleton<AudioManager>.instance.PlaySound("Sound/Voice/" + list[index], AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
				}
				if (this.audioHandle != 4294967295U)
				{
					NpcVoiceComponent.fLastPlayTime = Time.time;
				}
			}
		}
		if (eSoundEffectType == NpcVoiceComponent.SoundEffectType.SET_End)
		{
			eSoundEffectType = NpcVoiceComponent.SoundEffectType.SET_Random;
		}
	}

	// Token: 0x06019385 RID: 103301 RVA: 0x007FA6D0 File Offset: 0x007F8AD0
	public void Tick(float fdelta)
	{
		if (this.npcItem != null && this.eSoundEffectType == NpcVoiceComponent.SoundEffectType.SET_Random)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				BeTownNPC townNpcByNpcId = clientSystemTown.GetTownNpcByNpcId(this.iNpcID);
				if (townNpcByNpcId != null)
				{
					BeTownNPCData beTownNPCData = townNpcByNpcId.ActorData as BeTownNPCData;
					if (beTownNPCData != null)
					{
						Vector3 vector = clientSystemTown.MainPlayer.ActorData.MoveData.Position - beTownNPCData.MoveData.Position;
						vector.y = 0f;
						float num = Mathf.Sqrt(vector.sqrMagnitude);
						if (num > NpcVoiceComponent.fMaxVoiceDistance)
						{
							return;
						}
					}
				}
			}
			if (NpcVoiceComponent.fLastPlayTime + this.fInterval < Time.time)
			{
				float num2 = Random.Range(0f, 1f);
				if (num2 <= (float)this.npcItem.Probability)
				{
					this.PlaySound(this.eSoundEffectType);
				}
			}
		}
	}

	// Token: 0x04012121 RID: 74017
	private int iNpcID;

	// Token: 0x04012122 RID: 74018
	private NpcTable npcItem;

	// Token: 0x04012123 RID: 74019
	private NpcVoiceComponent.SoundEffectType eSoundEffectType;

	// Token: 0x04012124 RID: 74020
	private IList<string>[] akSoundEffectsArray = new IList<string>[3];

	// Token: 0x04012125 RID: 74021
	private static float fLastPlayTime;

	// Token: 0x04012126 RID: 74022
	private static float fMaxVoiceDistance = 6.5f;

	// Token: 0x04012127 RID: 74023
	private float fInterval;

	// Token: 0x04012128 RID: 74024
	private uint audioHandle = uint.MaxValue;

	// Token: 0x02004613 RID: 17939
	public enum SoundEffectType
	{
		// Token: 0x0401212A RID: 74026
		SET_INVALID = -1,
		// Token: 0x0401212B RID: 74027
		SET_Random,
		// Token: 0x0401212C RID: 74028
		SET_Start,
		// Token: 0x0401212D RID: 74029
		SET_End,
		// Token: 0x0401212E RID: 74030
		SET_COUNT
	}
}
