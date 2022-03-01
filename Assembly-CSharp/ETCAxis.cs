using System;
using UnityEngine;

// Token: 0x02004937 RID: 18743
[Serializable]
public class ETCAxis
{
	// Token: 0x0601AF40 RID: 110400 RVA: 0x00849C5C File Offset: 0x0084805C
	public ETCAxis(string axisName)
	{
		this.name = axisName;
		this.enable = true;
		this.speed = 15f;
		this.invertedAxis = false;
		this.isEnertia = false;
		this.inertia = 0f;
		this.inertiaThreshold = 0.08f;
		this.axisValue = 0f;
		this.axisSpeedValue = 0f;
		this.gravity = 0f;
		this.isAutoStab = false;
		this.autoStabThreshold = 0.01f;
		this.autoStabSpeed = 10f;
		this.maxAngle = 90f;
		this.minAngle = 90f;
		this.axisState = ETCAxis.AxisState.None;
		this.maxOverTimeValue = 1f;
		this.overTimeStep = 1f;
		this.isValueOverTime = false;
		this.axisThreshold = 0.5f;
		this.deadValue = 0.1f;
		this.actionOn = ETCAxis.ActionOn.Press;
	}

	// Token: 0x170022BB RID: 8891
	// (get) Token: 0x0601AF41 RID: 110401 RVA: 0x00849D4C File Offset: 0x0084814C
	// (set) Token: 0x0601AF42 RID: 110402 RVA: 0x00849D54 File Offset: 0x00848154
	public Transform directTransform
	{
		get
		{
			return this._directTransform;
		}
		set
		{
			this._directTransform = value;
			if (this._directTransform != null)
			{
				this.directCharacterController = this._directTransform.GetComponent<CharacterController>();
				this.directRigidBody = this._directTransform.GetComponent<Rigidbody>();
			}
			else
			{
				this.directCharacterController = null;
			}
		}
	}

	// Token: 0x0601AF43 RID: 110403 RVA: 0x00849DA8 File Offset: 0x008481A8
	public void InitAxis()
	{
		if (this.autoLinkTagPlayer)
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		this.startAngle = this.GetAngle();
	}

	// Token: 0x0601AF44 RID: 110404 RVA: 0x00849E00 File Offset: 0x00848200
	public void UpdateAxis(float realValue, bool isOnDrag, ETCBase.ControlType type, bool deltaTime = true)
	{
		if ((this.autoLinkTagPlayer && this.player == null) || (this.player && !this.player.activeSelf))
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		if (this.isAutoStab && this.axisValue == 0f && this._directTransform)
		{
			this.DoAutoStabilisation();
		}
		if (this.invertedAxis)
		{
			realValue *= -1f;
		}
		if (this.isValueOverTime && realValue != 0f)
		{
			this.axisValue += this.overTimeStep * Mathf.Sign(realValue) * Time.deltaTime;
			if (Mathf.Sign(this.axisValue) > 0f)
			{
				this.axisValue = Mathf.Clamp(this.axisValue, 0f, this.maxOverTimeValue);
			}
			else
			{
				this.axisValue = Mathf.Clamp(this.axisValue, -this.maxOverTimeValue, 0f);
			}
		}
		this.ComputAxisValue(realValue, type, isOnDrag, deltaTime);
	}

	// Token: 0x0601AF45 RID: 110405 RVA: 0x00849F54 File Offset: 0x00848354
	public void UpdateButton()
	{
		if ((this.autoLinkTagPlayer && this.player == null) || (this.player && !this.player.activeSelf))
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		if (this.isValueOverTime)
		{
			this.axisValue += this.overTimeStep * Time.deltaTime;
			this.axisValue = Mathf.Clamp(this.axisValue, 0f, this.maxOverTimeValue);
		}
		else if (this.axisState == ETCAxis.AxisState.Press || this.axisState == ETCAxis.AxisState.Down)
		{
			this.axisValue = 1f;
		}
		else
		{
			this.axisValue = 0f;
		}
		ETCAxis.ActionOn actionOn = this.actionOn;
		if (actionOn != ETCAxis.ActionOn.Down)
		{
			if (actionOn == ETCAxis.ActionOn.Press)
			{
				this.axisSpeedValue = this.axisValue * this.speed * Time.deltaTime;
				if (this.axisState == ETCAxis.AxisState.Press)
				{
					this.DoDirectAction();
				}
			}
		}
		else
		{
			this.axisSpeedValue = this.axisValue * this.speed;
			if (this.axisState == ETCAxis.AxisState.Down)
			{
				this.DoDirectAction();
			}
		}
	}

	// Token: 0x0601AF46 RID: 110406 RVA: 0x0084A0BC File Offset: 0x008484BC
	public void ResetAxis()
	{
		if (!this.isEnertia || (this.isEnertia && Mathf.Abs(this.axisValue) < this.inertiaThreshold))
		{
			this.axisValue = 0f;
			this.axisSpeedValue = 0f;
		}
	}

	// Token: 0x0601AF47 RID: 110407 RVA: 0x0084A10C File Offset: 0x0084850C
	public void DoDirectAction()
	{
		if (this.directTransform)
		{
			Vector3 influencedAxis = this.GetInfluencedAxis();
			switch (this.directAction)
			{
			case ETCAxis.DirectAction.Rotate:
				this.directTransform.Rotate(influencedAxis * this.axisSpeedValue, 0);
				break;
			case ETCAxis.DirectAction.RotateLocal:
				this.directTransform.Rotate(influencedAxis * this.axisSpeedValue, 1);
				break;
			case ETCAxis.DirectAction.Translate:
				if (this.directCharacterController == null)
				{
					this.directTransform.Translate(influencedAxis * this.axisSpeedValue, 0);
				}
				else if (this.directCharacterController.isGrounded || !this.isLockinJump)
				{
					Vector3 vector = influencedAxis * this.axisSpeedValue;
					this.directCharacterController.Move(vector);
					this.lastMove = influencedAxis * (this.axisSpeedValue / Time.deltaTime);
				}
				else
				{
					this.directCharacterController.Move(this.lastMove * Time.deltaTime);
				}
				break;
			case ETCAxis.DirectAction.TranslateLocal:
				if (this.directCharacterController == null)
				{
					this.directTransform.Translate(influencedAxis * this.axisSpeedValue, 1);
				}
				else if (this.directCharacterController.isGrounded || !this.isLockinJump)
				{
					Vector3 vector2 = this.directCharacterController.transform.TransformDirection(influencedAxis) * this.axisSpeedValue;
					this.directCharacterController.Move(vector2);
					this.lastMove = this.directCharacterController.transform.TransformDirection(influencedAxis) * (this.axisSpeedValue / Time.deltaTime);
				}
				else
				{
					this.directCharacterController.Move(this.lastMove * Time.deltaTime);
				}
				break;
			case ETCAxis.DirectAction.Scale:
				this.directTransform.localScale += influencedAxis * this.axisSpeedValue;
				break;
			case ETCAxis.DirectAction.Force:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddForce(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.RelativeForce:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddRelativeForce(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.Torque:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddTorque(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.RelativeTorque:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddRelativeTorque(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.Jump:
				if (this.directCharacterController != null && !this.isJump)
				{
					this.isJump = true;
					this.currentGravity = this.speed;
				}
				break;
			}
			if (this.isClampRotation && this.directAction == ETCAxis.DirectAction.RotateLocal)
			{
				this.DoAngleLimitation();
			}
		}
	}

	// Token: 0x0601AF48 RID: 110408 RVA: 0x0084A508 File Offset: 0x00848908
	public void DoGravity()
	{
		if (this.directCharacterController != null && this.gravity != 0f)
		{
			if (!this.isJump)
			{
				Vector3 vector;
				vector..ctor(0f, -this.gravity, 0f);
				this.directCharacterController.Move(vector * Time.deltaTime);
			}
			else
			{
				this.currentGravity -= this.gravity * Time.deltaTime;
				Vector3 vector2;
				vector2..ctor(0f, this.currentGravity, 0f);
				this.directCharacterController.Move(vector2 * Time.deltaTime);
			}
			if (this.directCharacterController.isGrounded)
			{
				this.isJump = false;
				this.currentGravity = 0f;
			}
		}
	}

	// Token: 0x0601AF49 RID: 110409 RVA: 0x0084A5E0 File Offset: 0x008489E0
	private void ComputAxisValue(float realValue, ETCBase.ControlType type, bool isOnDrag, bool deltaTime)
	{
		if (this.enable)
		{
			if (type == ETCBase.ControlType.Joystick)
			{
				if (this.valueMethod == ETCAxis.AxisValueMethod.Classical)
				{
					float num = Mathf.Max(Mathf.Abs(realValue), 0.001f);
					float num2 = Mathf.Max(num - this.deadValue, 0f) / (1f - this.deadValue) / num;
					realValue *= num2;
				}
				else
				{
					realValue = this.curveValue.Evaluate(realValue);
				}
			}
			if (this.isEnertia)
			{
				realValue -= this.axisValue;
				realValue /= this.inertia;
				this.axisValue += realValue;
				if (Mathf.Abs(this.axisValue) < this.inertiaThreshold && !isOnDrag)
				{
					this.axisValue = 0f;
				}
			}
			else if (!this.isValueOverTime || (this.isValueOverTime && realValue == 0f))
			{
				this.axisValue = realValue;
			}
			if (deltaTime)
			{
				this.axisSpeedValue = this.axisValue * this.speed * Time.deltaTime;
			}
			else
			{
				this.axisSpeedValue = this.axisValue * this.speed;
			}
		}
		else
		{
			this.axisValue = 0f;
			this.axisSpeedValue = 0f;
		}
	}

	// Token: 0x0601AF4A RID: 110410 RVA: 0x0084A728 File Offset: 0x00848B28
	private Vector3 GetInfluencedAxis()
	{
		Vector3 result = Vector3.zero;
		ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
		if (axisInfluenced != ETCAxis.AxisInfluenced.X)
		{
			if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
			{
				if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
				{
					result = Vector3.forward;
				}
			}
			else
			{
				result = Vector3.up;
			}
		}
		else
		{
			result = Vector3.right;
		}
		return result;
	}

	// Token: 0x0601AF4B RID: 110411 RVA: 0x0084A780 File Offset: 0x00848B80
	private float GetAngle()
	{
		float num = 0f;
		if (this._directTransform != null)
		{
			ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
			if (axisInfluenced != ETCAxis.AxisInfluenced.X)
			{
				if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
				{
					if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
					{
						num = this._directTransform.localRotation.eulerAngles.z;
					}
				}
				else
				{
					num = this._directTransform.localRotation.eulerAngles.y;
				}
			}
			else
			{
				num = this._directTransform.localRotation.eulerAngles.x;
			}
			if (num <= 360f && num >= 180f)
			{
				num -= 360f;
			}
		}
		return num;
	}

	// Token: 0x0601AF4C RID: 110412 RVA: 0x0084A84C File Offset: 0x00848C4C
	private void DoAutoStabilisation()
	{
		float num = this.GetAngle();
		if (num <= 360f && num >= 180f)
		{
			num -= 360f;
		}
		if (num > this.startAngle - this.autoStabThreshold || num < this.startAngle + this.autoStabThreshold)
		{
			float num2 = 0f;
			Vector3 zero = Vector3.zero;
			if (num > this.startAngle - this.autoStabThreshold)
			{
				num2 = num + this.autoStabSpeed / 100f * Mathf.Abs(num - this.startAngle) * Time.deltaTime * -1f;
			}
			if (num < this.startAngle + this.autoStabThreshold)
			{
				num2 = num + this.autoStabSpeed / 100f * Mathf.Abs(num - this.startAngle) * Time.deltaTime;
			}
			ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
			if (axisInfluenced != ETCAxis.AxisInfluenced.X)
			{
				if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
				{
					if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
					{
						zero..ctor(this._directTransform.localRotation.eulerAngles.x, this._directTransform.localRotation.eulerAngles.y, num2);
					}
				}
				else
				{
					zero..ctor(this._directTransform.localRotation.eulerAngles.x, num2, this._directTransform.localRotation.eulerAngles.z);
				}
			}
			else
			{
				zero..ctor(num2, this._directTransform.localRotation.eulerAngles.y, this._directTransform.localRotation.eulerAngles.z);
			}
			this._directTransform.localRotation = Quaternion.Euler(zero);
		}
	}

	// Token: 0x0601AF4D RID: 110413 RVA: 0x0084AA28 File Offset: 0x00848E28
	private void DoAngleLimitation()
	{
		Quaternion localRotation = this._directTransform.localRotation;
		localRotation.x /= localRotation.w;
		localRotation.y /= localRotation.w;
		localRotation.z /= localRotation.w;
		localRotation.w = 1f;
		ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
		if (axisInfluenced != ETCAxis.AxisInfluenced.X)
		{
			if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
			{
				if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
				{
					float num = 114.59156f * Mathf.Atan(localRotation.z);
					num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
					localRotation.z = Mathf.Tan(0.008726646f * num);
				}
			}
			else
			{
				float num = 114.59156f * Mathf.Atan(localRotation.y);
				num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
				localRotation.y = Mathf.Tan(0.008726646f * num);
			}
		}
		else
		{
			float num = 114.59156f * Mathf.Atan(localRotation.x);
			num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
			localRotation.x = Mathf.Tan(0.008726646f * num);
		}
		this._directTransform.localRotation = localRotation;
	}

	// Token: 0x0601AF4E RID: 110414 RVA: 0x0084AB7B File Offset: 0x00848F7B
	public void InitDeadCurve()
	{
		this.curveValue = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		this.curveValue.postWrapMode = 4;
		this.curveValue.preWrapMode = 4;
	}

	// Token: 0x04012C40 RID: 76864
	public string name;

	// Token: 0x04012C41 RID: 76865
	public bool autoLinkTagPlayer;

	// Token: 0x04012C42 RID: 76866
	public string autoTag = "Player";

	// Token: 0x04012C43 RID: 76867
	public GameObject player;

	// Token: 0x04012C44 RID: 76868
	public bool enable;

	// Token: 0x04012C45 RID: 76869
	public bool invertedAxis;

	// Token: 0x04012C46 RID: 76870
	public float speed;

	// Token: 0x04012C47 RID: 76871
	public float deadValue;

	// Token: 0x04012C48 RID: 76872
	public ETCAxis.AxisValueMethod valueMethod;

	// Token: 0x04012C49 RID: 76873
	public AnimationCurve curveValue;

	// Token: 0x04012C4A RID: 76874
	public bool isEnertia;

	// Token: 0x04012C4B RID: 76875
	public float inertia;

	// Token: 0x04012C4C RID: 76876
	public float inertiaThreshold;

	// Token: 0x04012C4D RID: 76877
	public bool isAutoStab;

	// Token: 0x04012C4E RID: 76878
	public float autoStabThreshold;

	// Token: 0x04012C4F RID: 76879
	public float autoStabSpeed;

	// Token: 0x04012C50 RID: 76880
	private float startAngle;

	// Token: 0x04012C51 RID: 76881
	public bool isClampRotation;

	// Token: 0x04012C52 RID: 76882
	public float maxAngle;

	// Token: 0x04012C53 RID: 76883
	public float minAngle;

	// Token: 0x04012C54 RID: 76884
	public bool isValueOverTime;

	// Token: 0x04012C55 RID: 76885
	public float overTimeStep;

	// Token: 0x04012C56 RID: 76886
	public float maxOverTimeValue;

	// Token: 0x04012C57 RID: 76887
	public float axisValue;

	// Token: 0x04012C58 RID: 76888
	public float axisSpeedValue;

	// Token: 0x04012C59 RID: 76889
	public float axisThreshold;

	// Token: 0x04012C5A RID: 76890
	public bool isLockinJump;

	// Token: 0x04012C5B RID: 76891
	private Vector3 lastMove;

	// Token: 0x04012C5C RID: 76892
	public ETCAxis.AxisState axisState;

	// Token: 0x04012C5D RID: 76893
	[SerializeField]
	private Transform _directTransform;

	// Token: 0x04012C5E RID: 76894
	public ETCAxis.DirectAction directAction;

	// Token: 0x04012C5F RID: 76895
	public ETCAxis.AxisInfluenced axisInfluenced;

	// Token: 0x04012C60 RID: 76896
	public ETCAxis.ActionOn actionOn;

	// Token: 0x04012C61 RID: 76897
	public CharacterController directCharacterController;

	// Token: 0x04012C62 RID: 76898
	public Rigidbody directRigidBody;

	// Token: 0x04012C63 RID: 76899
	public float gravity;

	// Token: 0x04012C64 RID: 76900
	public float currentGravity;

	// Token: 0x04012C65 RID: 76901
	public bool isJump;

	// Token: 0x04012C66 RID: 76902
	public string unityAxis;

	// Token: 0x04012C67 RID: 76903
	public bool showGeneralInspector;

	// Token: 0x04012C68 RID: 76904
	public bool showDirectInspector;

	// Token: 0x04012C69 RID: 76905
	public bool showInertiaInspector;

	// Token: 0x04012C6A RID: 76906
	public bool showSimulatinInspector;

	// Token: 0x02004938 RID: 18744
	public enum DirectAction
	{
		// Token: 0x04012C6C RID: 76908
		Rotate,
		// Token: 0x04012C6D RID: 76909
		RotateLocal,
		// Token: 0x04012C6E RID: 76910
		Translate,
		// Token: 0x04012C6F RID: 76911
		TranslateLocal,
		// Token: 0x04012C70 RID: 76912
		Scale,
		// Token: 0x04012C71 RID: 76913
		Force,
		// Token: 0x04012C72 RID: 76914
		RelativeForce,
		// Token: 0x04012C73 RID: 76915
		Torque,
		// Token: 0x04012C74 RID: 76916
		RelativeTorque,
		// Token: 0x04012C75 RID: 76917
		Jump
	}

	// Token: 0x02004939 RID: 18745
	public enum AxisInfluenced
	{
		// Token: 0x04012C77 RID: 76919
		X,
		// Token: 0x04012C78 RID: 76920
		Y,
		// Token: 0x04012C79 RID: 76921
		Z
	}

	// Token: 0x0200493A RID: 18746
	public enum AxisValueMethod
	{
		// Token: 0x04012C7B RID: 76923
		Classical,
		// Token: 0x04012C7C RID: 76924
		Curve
	}

	// Token: 0x0200493B RID: 18747
	public enum AxisState
	{
		// Token: 0x04012C7E RID: 76926
		None,
		// Token: 0x04012C7F RID: 76927
		Down,
		// Token: 0x04012C80 RID: 76928
		Press,
		// Token: 0x04012C81 RID: 76929
		Up,
		// Token: 0x04012C82 RID: 76930
		DownUp,
		// Token: 0x04012C83 RID: 76931
		DownDown,
		// Token: 0x04012C84 RID: 76932
		DownLeft,
		// Token: 0x04012C85 RID: 76933
		DownRight,
		// Token: 0x04012C86 RID: 76934
		PressUp,
		// Token: 0x04012C87 RID: 76935
		PressDown,
		// Token: 0x04012C88 RID: 76936
		PressLeft,
		// Token: 0x04012C89 RID: 76937
		PressRight
	}

	// Token: 0x0200493C RID: 18748
	public enum ActionOn
	{
		// Token: 0x04012C8B RID: 76939
		Down,
		// Token: 0x04012C8C RID: 76940
		Press
	}
}
