using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000241 RID: 577
public class Player : MonoBehaviour
{
	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06001304 RID: 4868 RVA: 0x0006557C File Offset: 0x0006397C
	// (set) Token: 0x06001305 RID: 4869 RVA: 0x00065584 File Offset: 0x00063984
	public float Speed { get; set; }

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06001306 RID: 4870 RVA: 0x0006558D File Offset: 0x0006398D
	// (set) Token: 0x06001307 RID: 4871 RVA: 0x00065595 File Offset: 0x00063995
	public bool IsForward { get; set; }

	// Token: 0x06001308 RID: 4872 RVA: 0x0006559E File Offset: 0x0006399E
	private void Start()
	{
		this.mPlayerOrient = Player.PlayerOrient.Idle;
		this.IsForward = true;
		base.StartCoroutine("SpecialIdle");
	}

	// Token: 0x06001309 RID: 4873 RVA: 0x000655BC File Offset: 0x000639BC
	private IEnumerator SpecialIdle()
	{
		float t = 2f;
		for (;;)
		{
			if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !this.Anim.IsInTransition(0))
			{
				t -= Time.deltaTime;
				if (t <= 0f)
				{
					this.Anim.SetBool("SpecialIdle", true);
					t = Random.Range(2f, 4f);
				}
			}
			else
			{
				this.Anim.SetBool("SpecialIdle", false);
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x0600130A RID: 4874 RVA: 0x000655D8 File Offset: 0x000639D8
	private void Update()
	{
		CharacterController component = base.GetComponent<CharacterController>();
		this.mLastAxisTime -= Time.deltaTime;
		if (this.mLastAxisTime <= 0f)
		{
			this.mLastAxis = Player.PlayerAxis.Null;
		}
		Player.PlayerAxis playerAxis = this.AxisButton();
		if (playerAxis != Player.PlayerAxis.Null)
		{
			if (this.mLastAxis == playerAxis)
			{
				this.mRunParameter = 1f;
			}
			this.mLastAxisTime = this.AxisSensitivity;
			this.mLastAxis = playerAxis;
		}
		bool flag = (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Kick") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("KickInOut") || (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("AttackInOut") || (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackLoop") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("AttackLoopInOut") || (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("SpecialAttack") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("SpecialAttackInOut");
		bool flag2 = (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("JumpBack") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("JumpBackInOut");
		bool flag3 = (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("JumpInOut");
		bool flag4 = (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Shovel") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("ShovelInOut");
		bool flag5 = (this.Anim.GetCurrentAnimatorStateInfo(1).IsName("WalkShoot") && !this.Anim.IsInTransition(1)) || this.Anim.GetAnimatorTransitionInfo(1).IsUserName("WalkShootInOut");
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) <= 0.1f && !flag3 && !flag4)
		{
			this.mRunParameter = 0.5f;
		}
		if (flag)
		{
			this.mForward = 0f;
			this.mRight = 0f;
			this.Speed = this.WalkSpeed;
			this.Anim.SetFloat("Run", 0f);
			if ((this.Anim.GetCurrentAnimatorStateInfo(0).IsName("AttackLoop") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("AttackLoopInOut"))
			{
				if (!Input.GetKey(106))
				{
					this.Anim.SetBool("AttackLoop", false);
				}
			}
			else if (((this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !this.Anim.IsInTransition(0)) || this.Anim.GetAnimatorTransitionInfo(0).IsUserName("AttackInOut")) && !Input.GetKey(106))
			{
				this.Anim.SetBool("AttackLoop", false);
			}
		}
		else if (flag2)
		{
			this.mForward = -1f;
			this.mRight = 0f;
			this.Speed = this.WalkSpeed;
			this.Anim.SetFloat("Run", 0f);
		}
		else
		{
			if (flag3 || flag4)
			{
				if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) <= 0.1f)
				{
					this.Anim.SetFloat("Run", 0f);
				}
				else
				{
					this.Anim.SetFloat("Run", this.mRunParameter);
				}
			}
			else
			{
				this.mForward = Input.GetAxisRaw("Horizontal");
				this.mRight = -Input.GetAxisRaw("Vertical");
				if (Mathf.Abs(this.mForward) > 0.1f || Mathf.Abs(this.mRight) > 0.1f)
				{
					this.Anim.SetFloat("Run", this.mRunParameter);
				}
				else
				{
					this.Anim.SetFloat("Run", 0f);
				}
				if (Input.GetKey(32))
				{
					this.Anim.SetTrigger("Jump");
					this.Anim.SetFloat("JumpAttack", 0f);
				}
				else if (Input.GetKey(109))
				{
					this.Anim.SetTrigger("Jump");
					this.Anim.SetFloat("JumpAttack", 1f);
				}
				else if (!this.SpecialSkill())
				{
					if (Input.GetKey(122))
					{
						this.Anim.SetTrigger("JumpBack");
					}
					else if (Input.GetKey(117))
					{
						this.Anim.SetTrigger("Kick");
						this.Anim.SetFloat("KickType", 0f);
					}
					else if (Input.GetKey(105))
					{
						this.Anim.SetTrigger("Kick");
						this.Anim.SetFloat("KickType", 1f);
					}
					else if (Input.GetKey(106) && !flag5)
					{
						this.Anim.SetTrigger("Attack");
						this.Anim.SetBool("AttackLoop", true);
						this.Anim.SetBool("WalkShootLoop", true);
					}
				}
			}
			this.Speed = ((this.mRunParameter <= 0.7f) ? this.WalkSpeed : this.RunSpeed);
		}
		if (flag5 && (!Input.GetKey(106) || this.Anim.GetFloat("Run") < 0.1f || this.Anim.GetFloat("Run") > 0.8f))
		{
			this.Anim.SetBool("WalkShootLoop", false);
		}
		Player.PlayerOrient playerOrient = this.CalcOrient();
		if (playerOrient != this.mPlayerOrient)
		{
			this.mPlayerOrient = playerOrient;
			this.ApplyOrient();
		}
		Vector3 vector = (base.transform.forward * this.mForward + base.transform.right * this.mRight) * this.Speed;
		vector *= Time.deltaTime;
		component.Move(vector);
	}

	// Token: 0x0600130B RID: 4875 RVA: 0x00065DA8 File Offset: 0x000641A8
	private Player.PlayerAxis AxisButton()
	{
		if (Input.GetButtonDown("Horizontal"))
		{
			float axisRaw = Input.GetAxisRaw("Horizontal");
			if (axisRaw > 0.5f)
			{
				return Player.PlayerAxis.Right;
			}
			if (axisRaw < -0.5f)
			{
				return Player.PlayerAxis.Left;
			}
		}
		if (Input.GetButtonDown("Vertical"))
		{
			float axisRaw2 = Input.GetAxisRaw("Vertical");
			if (axisRaw2 > 0.5f)
			{
				return Player.PlayerAxis.Up;
			}
			if (axisRaw2 < -0.5f)
			{
				return Player.PlayerAxis.Down;
			}
		}
		return Player.PlayerAxis.Null;
	}

	// Token: 0x0600130C RID: 4876 RVA: 0x00065E20 File Offset: 0x00064220
	private bool SpecialSkill()
	{
		if (Input.GetKey(49))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 1f);
		}
		else if (Input.GetKey(50))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 2f);
		}
		else if (Input.GetKey(51))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 3f);
		}
		else if (Input.GetKey(52))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 4f);
		}
		else if (Input.GetKey(53))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 5f);
		}
		else if (Input.GetKey(54))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 6f);
		}
		else if (Input.GetKey(55))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 7f);
		}
		else if (Input.GetKey(56))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 8f);
		}
		else if (Input.GetKey(57))
		{
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 9f);
		}
		else
		{
			if (!Input.GetKey(48))
			{
				return false;
			}
			this.Anim.SetTrigger("Special");
			this.Anim.SetFloat("SpecialAttack", 0f);
		}
		return true;
	}

	// Token: 0x0600130D RID: 4877 RVA: 0x0006604C File Offset: 0x0006444C
	private Player.PlayerOrient CalcOrient()
	{
		if (this.mForward > 0.1f)
		{
			return Player.PlayerOrient.Forward;
		}
		if (this.mForward < -0.1f)
		{
			return Player.PlayerOrient.Back;
		}
		return Player.PlayerOrient.Idle;
	}

	// Token: 0x0600130E RID: 4878 RVA: 0x00066074 File Offset: 0x00064474
	private void ApplyOrient()
	{
		if (this.mPlayerOrient == Player.PlayerOrient.Forward)
		{
			this.Anim.transform.localScale = this.ForwardScale;
			this.IsForward = true;
		}
		else if (this.mPlayerOrient == Player.PlayerOrient.Back)
		{
			this.Anim.transform.localScale = this.BackScale;
			this.IsForward = false;
		}
	}

	// Token: 0x04000CA0 RID: 3232
	public float WalkSpeed = 5f;

	// Token: 0x04000CA1 RID: 3233
	public float RunSpeed = 10f;

	// Token: 0x04000CA2 RID: 3234
	public Animator Anim;

	// Token: 0x04000CA3 RID: 3235
	public Vector3 ForwardScale = Vector3.one;

	// Token: 0x04000CA4 RID: 3236
	public Vector3 BackScale = Vector3.one;

	// Token: 0x04000CA5 RID: 3237
	private float mForward;

	// Token: 0x04000CA6 RID: 3238
	private float mRight;

	// Token: 0x04000CA8 RID: 3240
	private Player.PlayerAxis mLastAxis;

	// Token: 0x04000CA9 RID: 3241
	private float mLastAxisTime = 0.1f;

	// Token: 0x04000CAA RID: 3242
	public float AxisSensitivity = 0.1f;

	// Token: 0x04000CAB RID: 3243
	private float mRunParameter = 0.5f;

	// Token: 0x04000CAC RID: 3244
	private Player.PlayerOrient mPlayerOrient;

	// Token: 0x02000242 RID: 578
	public enum PlayerAxis
	{
		// Token: 0x04000CAF RID: 3247
		Null,
		// Token: 0x04000CB0 RID: 3248
		Right,
		// Token: 0x04000CB1 RID: 3249
		Left,
		// Token: 0x04000CB2 RID: 3250
		Up,
		// Token: 0x04000CB3 RID: 3251
		Down
	}

	// Token: 0x02000243 RID: 579
	public enum PlayerOrient
	{
		// Token: 0x04000CB5 RID: 3253
		Forward,
		// Token: 0x04000CB6 RID: 3254
		Idle,
		// Token: 0x04000CB7 RID: 3255
		Back
	}
}
