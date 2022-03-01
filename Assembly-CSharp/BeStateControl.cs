using System;

// Token: 0x0200417F RID: 16767
public class BeStateControl
{
	// Token: 0x0601700A RID: 94218 RVA: 0x0070FCAC File Offset: 0x0070E0AC
	public BeStateControl(BeEntity owner)
	{
		this.owner = owner;
		this.Reset();
	}

	// Token: 0x17001F6F RID: 8047
	// (get) Token: 0x0601700B RID: 94219 RVA: 0x0070FCFE File Offset: 0x0070E0FE
	public CrypticInt32[] Ability
	{
		get
		{
			return this.ability;
		}
	}

	// Token: 0x0601700C RID: 94220 RVA: 0x0070FD08 File Offset: 0x0070E108
	public void Reset()
	{
		for (int i = 0; i < 53; i++)
		{
			this.ability[i] = 1;
			this.bornAbility[i] = 1;
		}
	}

	// Token: 0x0601700D RID: 94221 RVA: 0x0070FD56 File Offset: 0x0070E156
	public bool HasState(BeStateType target)
	{
		return this.stateFlag.HasFlag((int)target);
	}

	// Token: 0x0601700E RID: 94222 RVA: 0x0070FD64 File Offset: 0x0070E164
	public void SetState(BeStateType target, bool clear = false)
	{
		if (clear)
		{
			this.stateFlag.ClearFlag((int)target);
		}
		else
		{
			this.stateFlag.SetFlag((int)target, null);
		}
	}

	// Token: 0x0601700F RID: 94223 RVA: 0x0070FD8A File Offset: 0x0070E18A
	public bool HasBuffState(BeBuffStateType target)
	{
		return this.buffStateFlag.HasFlag((int)target);
	}

	// Token: 0x06017010 RID: 94224 RVA: 0x0070FD98 File Offset: 0x0070E198
	public void SetBuffState(BeBuffStateType target, bool clear = false)
	{
		if (clear)
		{
			this.buffStateFlag.ClearFlag((int)target);
		}
		else
		{
			this.buffStateFlag.SetFlag((int)target, null);
		}
	}

	// Token: 0x06017011 RID: 94225 RVA: 0x0070FDBE File Offset: 0x0070E1BE
	public void ResetMoveAbility()
	{
		this.ability[1] = 1;
	}

	// Token: 0x06017012 RID: 94226 RVA: 0x0070FDD7 File Offset: 0x0070E1D7
	public void ResetAttackAbility()
	{
		this.ability[46] = 1;
	}

	// Token: 0x06017013 RID: 94227 RVA: 0x0070FDF1 File Offset: 0x0070E1F1
	public bool HasAbility(BeAbilityType abilityType)
	{
		return this.ability[(int)abilityType] > 0;
	}

	// Token: 0x06017014 RID: 94228 RVA: 0x0070FE0C File Offset: 0x0070E20C
	public bool HasBornAbility(BeAbilityType abilityType)
	{
		return this.bornAbility[(int)abilityType] > 0;
	}

	// Token: 0x06017015 RID: 94229 RVA: 0x0070FE28 File Offset: 0x0070E228
	public void SetBornAbility(BeAbilityType abilityType, bool enable)
	{
		if (enable)
		{
			CrypticInt32[] array = this.bornAbility;
			array[(int)abilityType] = array[(int)abilityType] + 1;
		}
		else
		{
			CrypticInt32[] array2 = this.bornAbility;
			array2[(int)abilityType] = array2[(int)abilityType] - 1;
		}
	}

	// Token: 0x06017016 RID: 94230 RVA: 0x0070FE88 File Offset: 0x0070E288
	public void SetAbilityEnable(BeAbilityType abilityType, bool enable)
	{
		if (enable)
		{
			CrypticInt32[] array = this.ability;
			array[(int)abilityType] = array[(int)abilityType] + 1;
		}
		else
		{
			CrypticInt32[] array2 = this.ability;
			array2[(int)abilityType] = array2[(int)abilityType] - 1;
		}
	}

	// Token: 0x06017017 RID: 94231 RVA: 0x0070FEE6 File Offset: 0x0070E2E6
	public void SetGrabStat(GrabState state)
	{
		this.grabState = state;
	}

	// Token: 0x06017018 RID: 94232 RVA: 0x0070FEEF File Offset: 0x0070E2EF
	public bool WillBeGrab()
	{
		return this.grabState == GrabState.WILL_BEGRAB;
	}

	// Token: 0x06017019 RID: 94233 RVA: 0x0070FEFA File Offset: 0x0070E2FA
	public bool IsGraping()
	{
		return this.grabState == GrabState.GRAPING;
	}

	// Token: 0x0601701A RID: 94234 RVA: 0x0070FF05 File Offset: 0x0070E305
	public bool IsBeingGrab()
	{
		return this.grabState == GrabState.BEING_GRAB;
	}

	// Token: 0x0601701B RID: 94235 RVA: 0x0070FF10 File Offset: 0x0070E310
	public bool isEndGrab()
	{
		return this.grabState == GrabState.ENDGRAPING;
	}

	// Token: 0x0601701C RID: 94236 RVA: 0x0070FF1C File Offset: 0x0070E31C
	public bool CanBeGrap()
	{
		bool flag = !this.HasAbility(BeAbilityType.BEGRAB);
		return !flag;
	}

	// Token: 0x0601701D RID: 94237 RVA: 0x0070FF38 File Offset: 0x0070E338
	public bool CanBeForceBreakAction()
	{
		return this.HasAbility(BeAbilityType.BEBREAK_FORCE);
	}

	// Token: 0x0601701E RID: 94238 RVA: 0x0070FF44 File Offset: 0x0070E344
	public bool CanBeBreakAction()
	{
		return this.HasAbility(BeAbilityType.BEBREAK) && this.CanBeHit();
	}

	// Token: 0x0601701F RID: 94239 RVA: 0x0070FF6C File Offset: 0x0070E36C
	public bool CanBeFloat()
	{
		bool flag = !this.HasAbility(BeAbilityType.FLOAT);
		return !flag;
	}

	// Token: 0x06017020 RID: 94240 RVA: 0x0070FF88 File Offset: 0x0070E388
	public bool CanMove()
	{
		return this.HasAbility(BeAbilityType.MOVE);
	}

	// Token: 0x06017021 RID: 94241 RVA: 0x0070FF91 File Offset: 0x0070E391
	public bool CanAttack()
	{
		return this.HasAbility(BeAbilityType.ATTACK);
	}

	// Token: 0x06017022 RID: 94242 RVA: 0x0070FF9A File Offset: 0x0070E39A
	public bool CanBeHit()
	{
		return this.HasAbility(BeAbilityType.BEHIT);
	}

	// Token: 0x06017023 RID: 94243 RVA: 0x0070FFA3 File Offset: 0x0070E3A3
	public bool BlockByScene()
	{
		return this.HasAbility(BeAbilityType.BLOCK);
	}

	// Token: 0x06017024 RID: 94244 RVA: 0x0070FFAD File Offset: 0x0070E3AD
	public bool IgnoreGravity()
	{
		return !this.HasAbility(BeAbilityType.GRAVITY);
	}

	// Token: 0x06017025 RID: 94245 RVA: 0x0070FFBA File Offset: 0x0070E3BA
	public bool CanTurnFace()
	{
		return this.HasAbility(BeAbilityType.CHANGE_FACE);
	}

	// Token: 0x06017026 RID: 94246 RVA: 0x0070FFC4 File Offset: 0x0070E3C4
	public bool CanDuplicate()
	{
		return this.HasAbility(BeAbilityType.DUPLICATE);
	}

	// Token: 0x06017027 RID: 94247 RVA: 0x0070FFCE File Offset: 0x0070E3CE
	public bool CanMoveX()
	{
		return this.HasAbility(BeAbilityType.X_MOVE);
	}

	// Token: 0x06017028 RID: 94248 RVA: 0x0070FFD8 File Offset: 0x0070E3D8
	public bool CanMoveY()
	{
		return this.HasAbility(BeAbilityType.Y_MOVE);
	}

	// Token: 0x06017029 RID: 94249 RVA: 0x0070FFE2 File Offset: 0x0070E3E2
	public bool CanMoveZ()
	{
		return this.HasAbility(BeAbilityType.Z_MOVE);
	}

	// Token: 0x0601702A RID: 94250 RVA: 0x0070FFEC File Offset: 0x0070E3EC
	public bool CanAddBuff()
	{
		return this.HasAbility(BeAbilityType.ADD_BUFF);
	}

	// Token: 0x0601702B RID: 94251 RVA: 0x0070FFF6 File Offset: 0x0070E3F6
	public bool CanHurt()
	{
		return this.HasAbility(BeAbilityType.HAVE_HURT);
	}

	// Token: 0x0601702C RID: 94252 RVA: 0x00710000 File Offset: 0x0070E400
	public bool CanBeTargeted()
	{
		return this.HasAbility(BeAbilityType.BETARGETED);
	}

	// Token: 0x0601702D RID: 94253 RVA: 0x00710009 File Offset: 0x0070E409
	public bool IsChaosState()
	{
		return !this.HasAbility(BeAbilityType.CHAOS);
	}

	// Token: 0x0601702E RID: 94254 RVA: 0x00710016 File Offset: 0x0070E416
	public bool CanBeHitNoDamage()
	{
		return !this.HasAbility(BeAbilityType.BEHIT_NODAMAGE);
	}

	// Token: 0x0601702F RID: 94255 RVA: 0x00710023 File Offset: 0x0070E423
	public bool IgnoreFarDamage()
	{
		return !this.HasAbility(BeAbilityType.IGNOREFAR);
	}

	// Token: 0x06017030 RID: 94256 RVA: 0x00710030 File Offset: 0x0070E430
	public bool CanBeHitOnlyNear()
	{
		return !this.HasAbility(BeAbilityType.CANBEHITONLYNEAR);
	}

	// Token: 0x06017031 RID: 94257 RVA: 0x0071003D File Offset: 0x0070E43D
	public bool CanGrap()
	{
		return !this.HasAbility(BeAbilityType.CANNOTGRAP);
	}

	// Token: 0x06017032 RID: 94258 RVA: 0x0071004C File Offset: 0x0070E44C
	public bool CanAddAbnormalBuffWithBornAbility(BuffType buffType)
	{
		BeAbilityType abilityType = (BeAbilityType)(buffType + 4);
		return this.HasBornAbility(abilityType);
	}

	// Token: 0x06017033 RID: 94259 RVA: 0x00710064 File Offset: 0x0070E464
	public bool CanAddAbnormalBuffAbility(BuffType buffType)
	{
		BeAbilityType abilityType = (BeAbilityType)(buffType + 4);
		return this.HasAbility(abilityType);
	}

	// Token: 0x06017034 RID: 94260 RVA: 0x0071007C File Offset: 0x0070E47C
	public bool CanAddAbnormalBuff()
	{
		return this.HasAbility(BeAbilityType.CANADDABNORMALBUFF);
	}

	// Token: 0x06017035 RID: 94261 RVA: 0x00710086 File Offset: 0x0070E486
	public bool CanNotAbsorbByBlockHole()
	{
		return !this.HasAbility(BeAbilityType.CANNOTBE_SUCKED);
	}

	// Token: 0x06017036 RID: 94262 RVA: 0x00710093 File Offset: 0x0070E493
	public bool HaveSuperBati()
	{
		return !this.HasAbility(BeAbilityType.SUPER_BATI);
	}

	// Token: 0x06017037 RID: 94263 RVA: 0x007100A0 File Offset: 0x0070E4A0
	public bool IsInvisible()
	{
		return !this.HasAbility(BeAbilityType.ARROW_INVISIBLE);
	}

	// Token: 0x06017038 RID: 94264 RVA: 0x007100AD File Offset: 0x0070E4AD
	public bool NotRemoveTransDoor()
	{
		return !this.HasAbility(BeAbilityType.NOTREMOVE_TRANSDOOR);
	}

	// Token: 0x06017039 RID: 94265 RVA: 0x007100BA File Offset: 0x0070E4BA
	public bool CanAttackFriend()
	{
		return !this.HasAbility(BeAbilityType.CANATTACKFRIEND);
	}

	// Token: 0x0601703A RID: 94266 RVA: 0x007100C7 File Offset: 0x0070E4C7
	public bool CanAttackFriendAndEnemy()
	{
		return !this.HasAbility(BeAbilityType.ATTACK_FRIEND_ENEMY);
	}

	// Token: 0x0601703B RID: 94267 RVA: 0x007100D4 File Offset: 0x0070E4D4
	public bool CanAttackFriendAndEnemy2()
	{
		return !this.HasAbility(BeAbilityType.ATTACK_FRIEND_ENEMY_2);
	}

	// Token: 0x0601703C RID: 94268 RVA: 0x007100E1 File Offset: 0x0070E4E1
	public bool CanUpdateX()
	{
		return this.HasAbility(BeAbilityType.CAN_UPDATEX);
	}

	// Token: 0x0601703D RID: 94269 RVA: 0x007100EB File Offset: 0x0070E4EB
	public bool CanUpdateY()
	{
		return this.HasAbility(BeAbilityType.CAN_UPDATEY);
	}

	// Token: 0x0601703E RID: 94270 RVA: 0x007100F5 File Offset: 0x0070E4F5
	public bool CanUpdateZ()
	{
		return this.HasAbility(BeAbilityType.CAN_UPDATEZ);
	}

	// Token: 0x04010847 RID: 67655
	protected CrypticInt32[] ability = new CrypticInt32[53];

	// Token: 0x04010848 RID: 67656
	protected CrypticInt32[] bornAbility = new CrypticInt32[53];

	// Token: 0x04010849 RID: 67657
	protected SeFlag stateFlag = new SeFlag(0);

	// Token: 0x0401084A RID: 67658
	protected SeFlag buffStateFlag = new SeFlag(0);

	// Token: 0x0401084B RID: 67659
	protected GrabState grabState;

	// Token: 0x0401084C RID: 67660
	private BeEntity owner;
}
