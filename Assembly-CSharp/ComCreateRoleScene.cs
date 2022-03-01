using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200115E RID: 4446
public class ComCreateRoleScene : MonoBehaviour
{
	// Token: 0x0600A9C5 RID: 43461 RVA: 0x00240F50 File Offset: 0x0023F350
	public static void SelectRole(int idx)
	{
		ComCreateRoleScene._LoadActorLight(false);
		if (ComCreateRoleScene.CreatePhase)
		{
			ComCreateRoleScene.SetSelectRoleActive(true);
		}
		ComCreateRoleScene.SetDemoRoleActive(false);
		ComCreateRoleScene.ResetCamera();
		ComCreateRoleScene.onSelectRot = true;
		ComCreateRoleScene.CreatePhase = false;
		ComCreateRoleScene.curAngularSpeed = 120f;
		if (null != ComCreateRoleScene.ActorLightRoot)
		{
			ComCreateRoleScene.ActorLightRoot.transform.position = Vector3.zero;
		}
		if (ComCreateRoleScene.m_CurRoleIdx < ComCreateRoleScene.m_RoleList.Count)
		{
			ComCreateRoleScene.RoleDemoDesc roleDemoDesc = ComCreateRoleScene.m_RoleList[ComCreateRoleScene.m_CurRoleIdx];
			if (roleDemoDesc != null && roleDemoDesc.m_RoleActor != null)
			{
				roleDemoDesc.m_RoleActor.ChangeLayer(0);
			}
		}
		if (idx < ComCreateRoleScene.m_RoleList.Count)
		{
			ComCreateRoleScene.RoleDemoDesc roleDemoDesc2 = ComCreateRoleScene.m_RoleList[idx];
			if (roleDemoDesc2 != null && roleDemoDesc2.m_RoleActor != null)
			{
				roleDemoDesc2.m_RoleActor.ChangeLayer(9);
			}
		}
		ComCreateRoleScene._Rotate(idx);
	}

	// Token: 0x0600A9C6 RID: 43462 RVA: 0x0024103C File Offset: 0x0023F43C
	public static void FinishDragSelect()
	{
		if (ComCreateRoleScene.ActorSlot != null && ComCreateRoleScene.m_RoleList.Count > 0)
		{
			ComCreateRoleScene.curForce = 0f;
			float num = 360f / (float)ComCreateRoleScene.ActorSlot.Length;
			float num2 = num * 0.5f;
			int num3 = (int)(ComCreateRoleScene.curAngle + num * 0.5f) / (int)num % ComCreateRoleScene.ActorSlot.Length;
			num3 = ((num3 >= ComCreateRoleScene.m_RoleList.Count) ? (ComCreateRoleScene.m_RoleList.Count - 1) : num3);
			ComCreateRoleScene.curTarget = (float)(num3 * (360 / ComCreateRoleScene.ActorSlot.Length));
			if (num3 < ComCreateRoleScene.m_RoleList.Count)
			{
				ComCreateRoleScene.RoleDemoDesc roleDemoDesc = ComCreateRoleScene.m_RoleList[num3];
				if (roleDemoDesc != null && roleDemoDesc.m_RoleActor != null)
				{
					roleDemoDesc.m_RoleActor.ChangeLayer(9);
				}
			}
			SelectRoleFrame selectRoleFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(SelectRoleFrame)) as SelectRoleFrame;
			if (selectRoleFrame != null)
			{
				selectRoleFrame.SetSelectedID(num3);
			}
			ComCreateRoleScene.m_CurRoleIdx = num3;
			if (null != ComCreateRoleScene.ActorRoot)
			{
				ComCreateRoleScene.ActorRoot.transform.eulerAngles = new Vector3(0f, ComCreateRoleScene.curAngle, 0f);
			}
			ComCreateRoleScene.onSelectRot = true;
		}
	}

	// Token: 0x0600A9C7 RID: 43463 RVA: 0x0024117C File Offset: 0x0023F57C
	public static void SetSelectRoleActive(bool bActive)
	{
		if (ComCreateRoleScene.m_RoleList != null)
		{
			int i = 0;
			int count = ComCreateRoleScene.m_RoleList.Count;
			while (i < count)
			{
				if (ComCreateRoleScene.m_RoleList[i] != null)
				{
					GeDemoActor roleActor = ComCreateRoleScene.m_RoleList[i].m_RoleActor;
					if (roleActor != null && null != roleActor.avatarRoot)
					{
						roleActor.avatarRoot.SetActive(bActive);
						if (bActive)
						{
							roleActor.ChangeState(ComCreateRoleScene.m_RoleList[i].m_JobString + ComCreateRoleScene.m_stateTable[1]);
						}
					}
				}
				i++;
			}
		}
	}

	// Token: 0x0600A9C8 RID: 43464 RVA: 0x0024121C File Offset: 0x0023F61C
	public static void SetDemoRoleActive(bool bActive)
	{
		if (ComCreateRoleScene.m_DemoActor != null)
		{
			GeDemoActor roleActor = ComCreateRoleScene.m_DemoActor.m_RoleActor;
			if (roleActor != null)
			{
				roleActor.avatarRoot.SetActive(bActive);
				if (bActive)
				{
					roleActor.ChangeState(ComCreateRoleScene.m_DemoActor.m_JobString + ComCreateRoleScene.m_stateTable[1]);
				}
				else
				{
					roleActor.ClearEffect();
				}
			}
		}
		ComCreateRoleScene.CreatePhase = bActive;
	}

	// Token: 0x0600A9C9 RID: 43465 RVA: 0x00241284 File Offset: 0x0023F684
	public static void LoadDemoActor(int jobID, uint[] equipIDs)
	{
		if (ComCreateRoleScene.m_DemoActor == null)
		{
			ComCreateRoleScene.m_DemoActor = new ComCreateRoleScene.RoleDemoDesc();
		}
		if (ComCreateRoleScene.m_DemoActor.m_RoleActor == null)
		{
			ComCreateRoleScene.m_DemoActor.m_RoleActor = new GeDemoActor();
		}
		ComCreateRoleScene.CreatePhase = true;
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobID / 10 * 10, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogError("职业ID找不到 ID = [" + jobID + "]\n");
			return;
		}
		ComCreateRoleScene._LoadActorLight(true);
		if (ComCreateRoleScene.m_DemoActor.m_RoleActor != null)
		{
			ComCreateRoleScene.m_DemoActor.m_RoleActor.Deinit();
		}
		Utility.LoadDemoActor(ComCreateRoleScene.m_DemoActor.m_RoleActor, jobID, true);
		if (tableItem.JobShowPath.Count > 0)
		{
			string text = tableItem.JobShowPath[0];
			for (int i = 0; i < ComCreateRoleScene.m_animTable.Length; i++)
			{
				ComCreateRoleScene.curJobString = null;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new char[]
					{
						'/'
					});
					ComCreateRoleScene.curJobString = array[array.Length - 1];
					ComCreateRoleScene.curJobString = ComCreateRoleScene.curJobString.Replace("Show", null);
				}
				ComCreateRoleScene.m_DemoActor.m_RoleActor.LoadState(text + "/" + ComCreateRoleScene.curJobString + ComCreateRoleScene.m_stateTable[i]);
			}
		}
		string weaponRes = null;
		string text2 = null;
		bool lhand = false;
		bool rhand = false;
		if (jobID / 10 == 5)
		{
			text2 = "Actor/Hero_Gungirl/Camera/Prefabs/p_Hero_Gungirl_Show_camera";
			weaponRes = "Actor/Hero_Gungirl/WeaponShow/p_Hero_GunGirl_weapon_Show";
			lhand = true;
			rhand = true;
		}
		else if (jobID / 10 == 3)
		{
			text2 = "Actor/Hero_Magegirl/Camera/Prefabs/p_Hero_Magegirl_Show_camera";
			weaponRes = string.Empty;
			lhand = false;
			rhand = false;
		}
		else if (jobID / 10 == 2)
		{
			text2 = "Actor/Hero_Gunman/Camera/Prefabs/p_Hero_Gunman_Show_camera";
			weaponRes = "Actor/Hero_Gungirl/WeaponShow/p_Hero_GunGirl_weapon_Show";
			lhand = true;
			rhand = true;
		}
		else if (jobID / 10 == 1)
		{
			text2 = "Actor/Hero_Swordsman/Camera/Prefabs/p_Hero_Swordsman_Show_camera";
			weaponRes = "Actor/Hero_Swordsman/WeaponShow/p_Hero_Swordman_weapon_Show";
			rhand = true;
		}
		ComCreateRoleScene.ResetCamera();
		if (!string.IsNullOrEmpty(text2))
		{
			ComCreateRoleScene.m_DemoActor.m_CameraNode = Singleton<AssetLoader>.instance.LoadResAsGameObject(text2, true, 0U);
			if (null != ComCreateRoleScene.m_DemoActor.m_CameraNode)
			{
				if (null != Camera.current)
				{
					ComCreateRoleScene.sceneRoleCamera = Camera.current;
				}
				ComCreateRoleScene.curRoleCamera = ComCreateRoleScene.m_DemoActor.m_CameraNode.GetComponentInChildren<Camera>();
				ComCreateRoleScene.curCamAnim = ComCreateRoleScene.m_DemoActor.m_CameraNode.GetComponentInChildren<Animation>();
				if (null != ComCreateRoleScene.curRoleCamera && null != ComCreateRoleScene.curCamAnim)
				{
					ComCreateRoleScene.curCamAnim.Play();
					Camera.SetupCurrent(ComCreateRoleScene.curRoleCamera);
				}
			}
			ComCreateRoleScene.m_DemoActor.m_CameraNode.SetActive(false);
		}
		ComCreateRoleScene._EquipDemoWeapon(ComCreateRoleScene.m_DemoActor, weaponRes, lhand, rhand, 0, 18);
		ComCreateRoleScene.m_DemoActor.m_RoleActor.ChangeState(ComCreateRoleScene.curJobString + ComCreateRoleScene.m_stateTable[0]);
		ComCreateRoleScene.m_DemoActor.m_LightRefNode = ComCreateRoleScene.m_DemoActor.m_RoleActor.GeAttachNode("[actor]Crotch").transform;
		ComCreateRoleScene.m_DemoActor.m_InitHeight = ComCreateRoleScene.m_DemoActor.m_LightRefNode.position.y;
		SkinnedMeshRenderer[] componentsInChildren = ComCreateRoleScene.m_DemoActor.m_RoleActor.avatarRoot.GetComponentsInChildren<SkinnedMeshRenderer>();
		int j = 0;
		int num = componentsInChildren.Length;
		while (j < num)
		{
			if (null != componentsInChildren[j])
			{
				componentsInChildren[j].updateWhenOffscreen = true;
			}
			j++;
		}
		ComCreateRoleScene.canDragRot = false;
	}

	// Token: 0x0600A9CA RID: 43466 RVA: 0x002415FC File Offset: 0x0023F9FC
	public static void ResetCamera()
	{
		if (null != ComCreateRoleScene.sceneRoleCamera)
		{
			Camera.SetupCurrent(ComCreateRoleScene.sceneRoleCamera);
		}
		if (null != ComCreateRoleScene.curCamAnim)
		{
			ComCreateRoleScene.curCamAnim.Stop();
			ComCreateRoleScene.curCamAnim = null;
			ComCreateRoleScene.curRoleCamera = null;
			if (null != ComCreateRoleScene.m_DemoActor.m_CameraNode)
			{
				ComCreateRoleScene.m_DemoActor.m_CameraNode.SetActive(false);
				Object.Destroy(ComCreateRoleScene.m_DemoActor.m_CameraNode);
				ComCreateRoleScene.m_DemoActor.m_CameraNode = null;
			}
		}
	}

	// Token: 0x0600A9CB RID: 43467 RVA: 0x00241688 File Offset: 0x0023FA88
	protected static void _PrepareSlots(Vector3 piovt, float radius)
	{
		if (null == ComCreateRoleScene.ActorRoot)
		{
			ComCreateRoleScene.ActorRoot = new GameObject("CreateRoleRoot");
		}
		if (null != ComCreateRoleScene.ActorRoot)
		{
			if (ComCreateRoleScene.ActorSlot == null)
			{
				ComCreateRoleScene.ActorSlot = new GameObject[ComCreateRoleScene.MAX_ACTOR_NUM];
			}
			Matrix4x4 matrix4x = default(Matrix4x4);
			Quaternion quaternion = default(Quaternion);
			Vector3 vector;
			vector..ctor(radius, 0f, 0f);
			int i = 0;
			int num = ComCreateRoleScene.ActorSlot.Length;
			while (i < num)
			{
				if (null == ComCreateRoleScene.ActorSlot[i])
				{
					ComCreateRoleScene.ActorSlot[i] = new GameObject("RoleSlot" + i.ToString());
				}
				quaternion.eulerAngles = new Vector3(0f, (float)(-(float)(360 / num) * i + 90), 0f);
				matrix4x.SetTRS(Vector3.zero, quaternion, Vector3.one);
				Vector3 position = matrix4x.MultiplyPoint(vector);
				ComCreateRoleScene.ActorSlot[i].transform.position = position;
				ComCreateRoleScene.ActorSlot[i].transform.localEulerAngles = new Vector3(0f, (float)(-(float)(360 / num) * i), 0f);
				ComCreateRoleScene.ActorSlot[i].transform.SetParent(ComCreateRoleScene.ActorRoot.transform, true);
				i++;
			}
		}
	}

	// Token: 0x0600A9CC RID: 43468 RVA: 0x002417EC File Offset: 0x0023FBEC
	public static void _Rotate(int slotIdx)
	{
		if (slotIdx == ComCreateRoleScene.m_CurRoleIdx)
		{
			return;
		}
		if (slotIdx < ComCreateRoleScene.ActorSlot.Length && slotIdx != ComCreateRoleScene.m_CurRoleIdx)
		{
			ComCreateRoleScene.targetAngle = (float)(slotIdx * (360 / ComCreateRoleScene.ActorSlot.Length));
			while (ComCreateRoleScene.targetAngle <= 0f)
			{
				ComCreateRoleScene.targetAngle += 360f;
			}
			while (ComCreateRoleScene.targetAngle > 360f)
			{
				ComCreateRoleScene.targetAngle -= 360f;
			}
			while (ComCreateRoleScene.curAngle < 0f)
			{
				ComCreateRoleScene.curAngle += 360f;
			}
			while (ComCreateRoleScene.curAngle >= 360f)
			{
				ComCreateRoleScene.curAngle -= 360f;
			}
			ComCreateRoleScene.m_CurRoleIdx = slotIdx;
		}
	}

	// Token: 0x0600A9CD RID: 43469 RVA: 0x002418C8 File Offset: 0x0023FCC8
	public static void _DragRot(float delta)
	{
		if (ComCreateRoleScene.m_RoleList.Count < 2)
		{
			return;
		}
		ComCreateRoleScene.curForce = -delta;
		ComCreateRoleScene.onSelectRot = false;
		ComCreateRoleScene.curAngularSpeed = 120f;
		ComCreateRoleScene.hasAlign = false;
		if (ComCreateRoleScene.m_CurRoleIdx < ComCreateRoleScene.m_RoleList.Count)
		{
			ComCreateRoleScene.RoleDemoDesc roleDemoDesc = ComCreateRoleScene.m_RoleList[ComCreateRoleScene.m_CurRoleIdx];
			if (roleDemoDesc != null && roleDemoDesc.m_RoleActor != null)
			{
				roleDemoDesc.m_RoleActor.ChangeLayer(0);
			}
		}
	}

	// Token: 0x0600A9CE RID: 43470 RVA: 0x00241944 File Offset: 0x0023FD44
	public static void _DragRotActor(float delta)
	{
		if (ComCreateRoleScene.CreatePhase && ComCreateRoleScene.canDragRot)
		{
			ComCreateRoleScene.curRoleForce = -delta;
		}
	}

	// Token: 0x0600A9CF RID: 43471 RVA: 0x00241964 File Offset: 0x0023FD64
	public static void AddSelectActor(int jobID, uint[] equipIDs, int weaponStrengthenLv)
	{
		ComCreateRoleScene._PrepareSlots(Vector3.zero, 1f);
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobID / 10 * 10, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogError("职业ID找不到 ID = [" + jobID + "]\n");
			return;
		}
		ComCreateRoleScene.RoleDemoDesc roleDemoDesc = new ComCreateRoleScene.RoleDemoDesc();
		roleDemoDesc.m_RoleActor = new GeDemoActor();
		Utility.LoadDemoActor(roleDemoDesc.m_RoleActor, jobID, true);
		if (tableItem.JobShowPath.Count > 0)
		{
			string text = tableItem.JobShowPath[0];
			for (int i = 0; i < ComCreateRoleScene.m_animTable.Length; i++)
			{
				roleDemoDesc.m_JobString = null;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new char[]
					{
						'/'
					});
					roleDemoDesc.m_JobString = array[array.Length - 1];
					roleDemoDesc.m_JobString = roleDemoDesc.m_JobString.Replace("Show", null);
				}
				roleDemoDesc.m_RoleActor.LoadState(text + "/" + roleDemoDesc.m_JobString + ComCreateRoleScene.m_stateTable[i]);
			}
		}
		List<uint> list = new List<uint>();
		string text2 = null;
		if (equipIDs != null)
		{
			int j = 0;
			int num = equipIDs.Length;
			while (j < num)
			{
				string weaponResFormID = DataManager<PlayerBaseData>.GetInstance().GetWeaponResFormID((int)equipIDs[j]);
				if (string.IsNullOrEmpty(weaponResFormID))
				{
					list.Add(equipIDs[j]);
				}
				else
				{
					text2 = weaponResFormID;
				}
				j++;
			}
		}
		if (list.Count > 0)
		{
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(roleDemoDesc.m_RoleActor, list.ToArray(), jobID, weaponStrengthenLv, null, false, 0, false);
		}
		if (string.IsNullOrEmpty(text2))
		{
			JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobID, string.Empty, string.Empty);
			text2 = tableItem2.DefaultWeaponPath;
		}
		bool lhand = false;
		bool rhand = false;
		if (jobID / 10 == 5 || jobID / 10 == 2)
		{
			lhand = true;
			rhand = true;
		}
		else if (jobID / 10 == 1)
		{
			rhand = true;
		}
		ComCreateRoleScene._EquipDemoWeapon(roleDemoDesc, text2, lhand, rhand, weaponStrengthenLv, 18);
		roleDemoDesc.m_RoleActor.ChangeState(roleDemoDesc.m_JobString + ComCreateRoleScene.m_stateTable[1]);
		int num2 = (ComCreateRoleScene.m_RoleList.Count >= ComCreateRoleScene.ActorSlot.Length) ? (ComCreateRoleScene.ActorSlot.Length - 1) : ComCreateRoleScene.m_RoleList.Count;
		roleDemoDesc.m_RoleActor.avatarRoot.transform.SetParent(ComCreateRoleScene.ActorSlot[num2].transform, false);
		roleDemoDesc.m_RoleActor.ChangeLayer(0);
		ComCreateRoleScene.m_RoleList.Add(roleDemoDesc);
	}

	// Token: 0x0600A9D0 RID: 43472 RVA: 0x00241BFC File Offset: 0x0023FFFC
	public static void ClearSelectRole()
	{
		if (ComCreateRoleScene.m_RoleList != null)
		{
			int i = 0;
			int count = ComCreateRoleScene.m_RoleList.Count;
			while (i < count)
			{
				if (ComCreateRoleScene.m_RoleList[i] != null)
				{
					GeDemoActor roleActor = ComCreateRoleScene.m_RoleList[i].m_RoleActor;
					if (roleActor != null)
					{
						if (null != roleActor.avatarRoot)
						{
							roleActor.avatarRoot.transform.SetParent(null, false);
						}
						roleActor.Deinit();
					}
				}
				i++;
			}
		}
		ComCreateRoleScene.m_RoleList.Clear();
		if (null != ComCreateRoleScene.ActorRoot)
		{
			ComCreateRoleScene.ActorRoot.transform.eulerAngles = Vector3.zero;
		}
		if (ComCreateRoleScene.ActorSlot != null)
		{
			int j = 0;
			int num = ComCreateRoleScene.ActorSlot.Length;
			while (j < num)
			{
				if (null != ComCreateRoleScene.ActorSlot[j])
				{
					ComCreateRoleScene.ActorSlot[j].transform.position = Vector3.zero;
					ComCreateRoleScene.ActorSlot[j].transform.localEulerAngles = Vector3.zero;
				}
				j++;
			}
		}
		ComCreateRoleScene.curAngle = 0f;
		ComCreateRoleScene.targetAngle = 0f;
		ComCreateRoleScene.m_CurRoleIdx = 0;
		ComCreateRoleScene.curFactor = 1f;
	}

	// Token: 0x0600A9D1 RID: 43473 RVA: 0x00241D38 File Offset: 0x00240138
	public static void ClearDemoRole()
	{
		if (ComCreateRoleScene.m_DemoActor != null && ComCreateRoleScene.m_DemoActor.m_RoleActor != null)
		{
			ComCreateRoleScene.m_DemoActor.m_RoleActor.Deinit();
			ComCreateRoleScene.m_DemoActor.m_RoleActor = null;
		}
	}

	// Token: 0x0600A9D2 RID: 43474 RVA: 0x00241D70 File Offset: 0x00240170
	protected static void _EquipDemoWeapon(ComCreateRoleScene.RoleDemoDesc actorDesc, string weaponRes, bool LHand, bool RHand, int strengthLv = 0, int weaponLayer = 18)
	{
		if (actorDesc != null && actorDesc.m_RoleActor != null && !string.IsNullOrEmpty(weaponRes))
		{
			if (LHand)
			{
				actorDesc.m_LeftWeapon = actorDesc.m_RoleActor.AttachAvatar("weaponL", weaponRes, "[actor]LWeapon", true, true, false, 0f);
				actorDesc.m_LeftWeapon.SetLayer(weaponLayer);
				actorDesc.m_LeftWeapon.ChangePhase(BeUtility.GetStrengthenEffectName(actorDesc.m_LeftWeapon.ResPath), strengthLv, false);
			}
			if (RHand)
			{
				actorDesc.m_RightWeapon = actorDesc.m_RoleActor.AttachAvatar("weaponR", weaponRes, "[actor]RWeapon", true, true, false, 0f);
				actorDesc.m_RightWeapon.SetLayer(weaponLayer);
				actorDesc.m_RightWeapon.ChangePhase(BeUtility.GetStrengthenEffectName(actorDesc.m_RightWeapon.ResPath), strengthLv, false);
			}
		}
	}

	// Token: 0x0600A9D3 RID: 43475 RVA: 0x00241E43 File Offset: 0x00240243
	public static void CheckLoadCreateRoleScene()
	{
		if (!ComCreateRoleScene.sRoleSceneLoaded)
		{
			SceneManager.LoadScene(ComCreateRoleScene.sceneName, 1);
		}
	}

	// Token: 0x0600A9D4 RID: 43476 RVA: 0x00241E5C File Offset: 0x0024025C
	private void Update()
	{
		if (ComCreateRoleScene.CreatePhase)
		{
			if (ComCreateRoleScene.m_DemoActor != null && ComCreateRoleScene.m_DemoActor.m_RoleActor != null)
			{
				if (ComCreateRoleScene.m_DemoActor.m_RoleActor.IsCurActionEnd())
				{
					ComCreateRoleScene.canDragRot = true;
					ComCreateRoleScene.m_DemoActor.m_RoleActor.ChangeState(ComCreateRoleScene.curJobString + ComCreateRoleScene.m_ActionTable[ComCreateRoleScene.m_PlayList[ComCreateRoleScene.m_DemoActor.m_PlayIdx]]);
					ComCreateRoleScene.m_DemoActor.m_PlayIdx++;
					if (ComCreateRoleScene.m_DemoActor.m_PlayIdx >= ComCreateRoleScene.m_PlayList.Length)
					{
						ComCreateRoleScene.m_DemoActor.m_PlayIdx = Random.Range(0, ComCreateRoleScene.m_PlayList.Length);
					}
					ComCreateRoleScene.m_DemoActor.m_PlayIdx = ComCreateRoleScene.m_DemoActor.m_PlayIdx % ComCreateRoleScene.m_PlayList.Length;
				}
				ComCreateRoleScene.m_DemoActor.m_RoleActor.OnUpdate(0.033333335f);
				if (null != ComCreateRoleScene.ActorLightRoot && null != ComCreateRoleScene.m_DemoActor.m_LightRefNode)
				{
					Vector3 position = ComCreateRoleScene.ActorLightRoot.transform.position;
					position.y = ComCreateRoleScene.m_DemoActor.m_LightRefNode.position.y - ComCreateRoleScene.m_DemoActor.m_InitHeight;
					ComCreateRoleScene.ActorLightRoot.transform.position = position;
				}
				Vector3 eulerAngles = ComCreateRoleScene.m_DemoActor.m_RoleActor.avatarRoot.transform.eulerAngles;
				ComCreateRoleScene.curRoleForce *= ComCreateRoleScene.damp;
				eulerAngles.y += ComCreateRoleScene.curRoleForce;
				ComCreateRoleScene.m_DemoActor.m_RoleActor.avatarRoot.transform.eulerAngles = eulerAngles;
				if (null != ComCreateRoleScene.m_DemoActor.m_CameraNode && !ComCreateRoleScene.m_DemoActor.m_CameraNode.activeSelf)
				{
					ComCreateRoleScene.m_DemoActor.m_CameraNode.SetActive(true);
				}
			}
		}
		else
		{
			int i = 0;
			int count = ComCreateRoleScene.m_RoleList.Count;
			while (i < count)
			{
				if (ComCreateRoleScene.m_RoleList[i] != null)
				{
					GeDemoActor roleActor = ComCreateRoleScene.m_RoleList[i].m_RoleActor;
					roleActor.OnUpdate(0f);
					if (roleActor != null && i == ComCreateRoleScene.m_CurRoleIdx)
					{
						if (roleActor.IsCurActionEnd())
						{
							roleActor.ChangeState(ComCreateRoleScene.m_RoleList[i].m_JobString + ComCreateRoleScene.m_ActionTable[ComCreateRoleScene.m_PlayList[ComCreateRoleScene.m_RoleList[i].m_PlayIdx]]);
							ComCreateRoleScene.m_RoleList[i].m_PlayIdx++;
							if (ComCreateRoleScene.m_RoleList[i].m_PlayIdx >= ComCreateRoleScene.m_PlayList.Length)
							{
								ComCreateRoleScene.m_RoleList[i].m_PlayIdx = Random.Range(0, ComCreateRoleScene.m_PlayList.Length);
							}
							ComCreateRoleScene.m_RoleList[i].m_PlayIdx = ComCreateRoleScene.m_RoleList[i].m_PlayIdx % ComCreateRoleScene.m_PlayList.Length;
						}
						roleActor.OnUpdate(0.033333335f);
					}
				}
				i++;
			}
		}
		this._UpdateSelectRotation();
		this._UpdateDragRotation();
	}

	// Token: 0x0600A9D5 RID: 43477 RVA: 0x0024217C File Offset: 0x0024057C
	private void _UpdateSelectRotation()
	{
		if (!ComCreateRoleScene.onSelectRot)
		{
			return;
		}
		if (null != ComCreateRoleScene.ActorRoot)
		{
			if (Mathf.Abs(ComCreateRoleScene.curAngle - ComCreateRoleScene.targetAngle) >= 2f)
			{
				ComCreateRoleScene.curAngularAcc = Mathf.Abs((ComCreateRoleScene.curAngle - ComCreateRoleScene.targetAngle) / 30f);
				ComCreateRoleScene.curAngle += 0.016666668f * ComCreateRoleScene.curAngularSpeed * ComCreateRoleScene.curAngularAcc;
				while (ComCreateRoleScene.curAngle < 0f)
				{
					ComCreateRoleScene.curAngle += 360f;
				}
				while (ComCreateRoleScene.curAngle >= 360f)
				{
					ComCreateRoleScene.curAngle -= 360f;
				}
				ComCreateRoleScene.ActorRoot.transform.eulerAngles = new Vector3(0f, ComCreateRoleScene.curAngle, 0f);
			}
			else
			{
				ComCreateRoleScene.onSelectRot = false;
			}
		}
	}

	// Token: 0x0600A9D6 RID: 43478 RVA: 0x0024226C File Offset: 0x0024066C
	private void _UpdateDragRotation()
	{
		if (ComCreateRoleScene.onSelectRot)
		{
			return;
		}
		if (ComCreateRoleScene.m_RoleList.Count < 2)
		{
			return;
		}
		if (null != ComCreateRoleScene.ActorRoot)
		{
			if (Mathf.Abs(ComCreateRoleScene.curForce) >= 0.1f)
			{
				ComCreateRoleScene.curForce *= ComCreateRoleScene.damp;
				ComCreateRoleScene.curAngle += ComCreateRoleScene.curForce;
			}
			else
			{
				float num = 360f / (float)ComCreateRoleScene.ActorSlot.Length;
				float num2 = num * 0.5f;
				int num3 = (int)(ComCreateRoleScene.curAngle + num * 0.5f) / (int)num % ComCreateRoleScene.ActorSlot.Length;
				num3 = ((num3 >= ComCreateRoleScene.m_RoleList.Count) ? (ComCreateRoleScene.m_RoleList.Count - 1) : num3);
				ComCreateRoleScene.curTarget = (float)(num3 * (360 / ComCreateRoleScene.ActorSlot.Length));
				while (ComCreateRoleScene.curTarget <= 0f)
				{
					ComCreateRoleScene.curTarget += 360f;
				}
				while (ComCreateRoleScene.curTarget > 360f)
				{
					ComCreateRoleScene.curTarget -= 360f;
				}
				while (ComCreateRoleScene.curAngle <= 0f)
				{
					ComCreateRoleScene.curAngle += 360f;
				}
				while (ComCreateRoleScene.curAngle > 360f)
				{
					ComCreateRoleScene.curAngle -= 360f;
				}
				float num4;
				float num5;
				if (ComCreateRoleScene.curTarget - num2 < ComCreateRoleScene.curAngle && ComCreateRoleScene.curAngle < ComCreateRoleScene.curTarget)
				{
					num4 = ComCreateRoleScene.curTarget - ComCreateRoleScene.curAngle;
					num5 = 1f;
				}
				else if (ComCreateRoleScene.curTarget < ComCreateRoleScene.curAngle && ComCreateRoleScene.curAngle < ComCreateRoleScene.curTarget + num2)
				{
					num4 = ComCreateRoleScene.curTarget + num2 - ComCreateRoleScene.curAngle;
					num5 = -1f;
				}
				else
				{
					num4 = Mathf.Abs(ComCreateRoleScene.curTarget - ComCreateRoleScene.curAngle);
					num4 = ((num4 >= num2) ? (360f - num4) : num4);
					num5 = 1f;
				}
				float num6 = num4 / 30f;
				num6 = ((num6 <= 1f) ? num6 : 1f);
				if (num6 < 0.1f)
				{
					if (num3 < ComCreateRoleScene.m_RoleList.Count)
					{
						ComCreateRoleScene.RoleDemoDesc roleDemoDesc = ComCreateRoleScene.m_RoleList[num3];
						if (roleDemoDesc != null && roleDemoDesc.m_RoleActor != null)
						{
							roleDemoDesc.m_RoleActor.ChangeLayer(9);
						}
					}
					if (ComCreateRoleScene.lastIdx != num3)
					{
						SelectRoleFrame selectRoleFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(SelectRoleFrame)) as SelectRoleFrame;
						if (selectRoleFrame != null)
						{
							selectRoleFrame.SetSelectedID(num3);
						}
						ComCreateRoleScene.lastIdx = num3;
					}
					ComCreateRoleScene.m_CurRoleIdx = num3;
				}
				ComCreateRoleScene.curAngle += ComCreateRoleScene.TIME_SLICE * ComCreateRoleScene.curAngularSpeed * num6 * num5;
			}
			ComCreateRoleScene.ActorRoot.transform.eulerAngles = new Vector3(0f, ComCreateRoleScene.curAngle, 0f);
		}
	}

	// Token: 0x0600A9D7 RID: 43479 RVA: 0x00242570 File Offset: 0x00240970
	private void Start()
	{
		Singleton<GePhaseEffect>.instance.UnInit();
		Singleton<GePhaseEffect>.instance.Init();
		Scene sceneByName = SceneManager.GetSceneByName(ComCreateRoleScene.sceneName);
		SceneManager.SetActiveScene(sceneByName);
		this.LightNode = GameObject.Find("Environment/Directional light");
		this.CameraNode = GameObject.Find("Environment/FollowPlayer/Main Camera");
		if (this.LightNode == null || this.CameraNode == null)
		{
			Logger.LogErrorFormat("创建角色脚本没有找到 Environment环境，请查询创建流程", new object[0]);
		}
		if (this.LightNode != null)
		{
			this.LightNode.CustomActive(false);
		}
		if (this.CameraNode != null)
		{
			this.CameraNode.CustomActive(false);
		}
		ComCreateRoleScene.sRoleSceneLoaded = true;
		ComCreateRoleScene.sceneRoleCamera = Camera.current;
		ComCreateRoleScene.ActorLightRoot = null;
		ComCreateRoleScene.SceneRoot = GameObject.Find("HGCreateRoleRoot");
		ComCreateRoleScene.sEffect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/Start/Prefab/Eff_Start", true, 0U);
		this._PrepareActorRes();
	}

	// Token: 0x0600A9D8 RID: 43480 RVA: 0x00242670 File Offset: 0x00240A70
	private void OnDisable()
	{
		if (this.LightNode != null)
		{
			this.LightNode.CustomActive(true);
		}
		if (this.CameraNode != null)
		{
			this.CameraNode.CustomActive(true);
		}
		ComCreateRoleScene.sRoleSceneLoaded = false;
		if (ComCreateRoleScene.m_DemoActor != null)
		{
			if (ComCreateRoleScene.m_DemoActor.m_RoleActor != null)
			{
				ComCreateRoleScene.m_DemoActor.m_RoleActor.Deinit();
			}
			if (ComCreateRoleScene.m_RoleList != null)
			{
				int i = 0;
				int count = ComCreateRoleScene.m_RoleList.Count;
				while (i < count)
				{
					if (ComCreateRoleScene.m_RoleList[i] != null)
					{
						GeDemoActor roleActor = ComCreateRoleScene.m_RoleList[i].m_RoleActor;
						if (roleActor != null)
						{
							roleActor.Deinit();
						}
					}
					i++;
				}
			}
		}
		if (null != ComCreateRoleScene.ActorRoot)
		{
			Object.Destroy(ComCreateRoleScene.ActorRoot);
			ComCreateRoleScene.ActorRoot = null;
		}
	}

	// Token: 0x0600A9D9 RID: 43481 RVA: 0x0024275C File Offset: 0x00240B5C
	private void OnDestroy()
	{
		ComCreateRoleScene.ActorLightRoot.transform.position = Vector3.zero;
		if (this.LightNode != null)
		{
			this.LightNode.CustomActive(true);
		}
		if (this.CameraNode != null)
		{
			this.CameraNode.CustomActive(true);
		}
		SceneManager.UnloadScene(SceneManager.GetSceneByName(ComCreateRoleScene.sceneName).buildIndex);
		if (null != ComCreateRoleScene.sEffect)
		{
			Object.Destroy(ComCreateRoleScene.sEffect);
			ComCreateRoleScene.sEffect = null;
		}
		ComCreateRoleScene.sRoleSceneLoaded = false;
	}

	// Token: 0x0600A9DA RID: 43482 RVA: 0x002427F8 File Offset: 0x00240BF8
	protected void _PrepareActorRes()
	{
		GeDemoActor geDemoActor = new GeDemoActor();
		Utility.LoadDemoActor(geDemoActor, 10, true);
		geDemoActor.Deinit();
		Utility.LoadDemoActor(geDemoActor, 20, true);
		geDemoActor.Deinit();
		Utility.LoadDemoActor(geDemoActor, 30, true);
		geDemoActor.Deinit();
		Utility.LoadDemoActor(geDemoActor, 50, true);
		geDemoActor.Deinit();
	}

	// Token: 0x0600A9DB RID: 43483 RVA: 0x00242848 File Offset: 0x00240C48
	protected static void _LoadActorLight(bool createRole)
	{
		if (null != ComCreateRoleScene.SceneLightRoot)
		{
			Object.Destroy(ComCreateRoleScene.SceneLightRoot);
		}
		if (createRole)
		{
			ComCreateRoleScene.SceneLightRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("Scene/Start/Perfab/Light_chuangjue", true, 0U);
		}
		else
		{
			ComCreateRoleScene.SceneLightRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("Scene/Start/Perfab/Light_xuanjue", true, 0U);
		}
		if (null != ComCreateRoleScene.SceneLightRoot)
		{
			ComCreateRoleScene.SceneLightRoot.name = "Light";
			if (null != ComCreateRoleScene.SceneRoot)
			{
				ComCreateRoleScene.SceneLightRoot.transform.SetParent(ComCreateRoleScene.SceneRoot.transform, false);
			}
			Transform transform = ComCreateRoleScene.SceneLightRoot.transform.Find("Character Light");
			if (null != transform)
			{
				ComCreateRoleScene.ActorLightRoot = transform.gameObject;
			}
		}
	}

	// Token: 0x0600A9DC RID: 43484 RVA: 0x0024291C File Offset: 0x00240D1C
	// Note: this type is marked as 'beforefieldinit'.
	static ComCreateRoleScene()
	{
		int[] array = new int[8];
		array[2] = 1;
		array[5] = 2;
		ComCreateRoleScene.m_PlayList = array;
		ComCreateRoleScene.m_PlayIdx = 0;
		ComCreateRoleScene.jobIDHold = 0;
		ComCreateRoleScene.equipIDsHold = null;
		ComCreateRoleScene.weaponStrengthenLvHold = 0;
		ComCreateRoleScene.curJobString = string.Empty;
		ComCreateRoleScene.onSelectRot = false;
		ComCreateRoleScene.targetAngle = 0f;
		ComCreateRoleScene.curAngle = 0f;
		ComCreateRoleScene.curAngularSpeed = 0f;
		ComCreateRoleScene.curAngularAcc = 1f;
		ComCreateRoleScene.curFactor = 1f;
		ComCreateRoleScene.curForce = 0f;
		ComCreateRoleScene.curTarget = 0f;
		ComCreateRoleScene.damp = 0.8f;
		ComCreateRoleScene.lastIdx = -1;
		ComCreateRoleScene.hasAlign = false;
		ComCreateRoleScene.curRoleForce = 0f;
		ComCreateRoleScene.canDragRot = false;
		ComCreateRoleScene.m_animTable = new string[]
		{
			"Anim_Show",
			"Anim_Show_Idle",
			"Anim_Show_Idle_special01",
			"Anim_Show_Idle_special02"
		};
		ComCreateRoleScene.m_stateTable = new string[]
		{
			"Show",
			"Show_Idle",
			"Show_Idle_special01",
			"Show_Idle_special02"
		};
		ComCreateRoleScene.TIME_SLICE = 0.016666668f;
	}

	// Token: 0x04005EFA RID: 24314
	private GameObject LightNode;

	// Token: 0x04005EFB RID: 24315
	private GameObject CameraNode;

	// Token: 0x04005EFC RID: 24316
	private static Camera sceneRoleCamera = null;

	// Token: 0x04005EFD RID: 24317
	private static Camera curRoleCamera = null;

	// Token: 0x04005EFE RID: 24318
	private static Animation curCamAnim = null;

	// Token: 0x04005EFF RID: 24319
	private static readonly string sceneName = "Xuanjue3";

	// Token: 0x04005F00 RID: 24320
	private static GameObject SceneLightRoot = null;

	// Token: 0x04005F01 RID: 24321
	private static GameObject SceneRoot = null;

	// Token: 0x04005F02 RID: 24322
	private static GameObject ActorRoot;

	// Token: 0x04005F03 RID: 24323
	private static GameObject ActorLightRoot;

	// Token: 0x04005F04 RID: 24324
	private static readonly int MAX_ACTOR_NUM = 3;

	// Token: 0x04005F05 RID: 24325
	private static GameObject[] ActorSlot = new GameObject[ComCreateRoleScene.MAX_ACTOR_NUM];

	// Token: 0x04005F06 RID: 24326
	private static bool CreatePhase = false;

	// Token: 0x04005F07 RID: 24327
	protected static List<ComCreateRoleScene.RoleDemoDesc> m_RoleList = new List<ComCreateRoleScene.RoleDemoDesc>();

	// Token: 0x04005F08 RID: 24328
	protected static int m_CurRoleIdx = 0;

	// Token: 0x04005F09 RID: 24329
	protected static ComCreateRoleScene.RoleDemoDesc m_DemoActor = null;

	// Token: 0x04005F0A RID: 24330
	public static uint sCurRole = 0U;

	// Token: 0x04005F0B RID: 24331
	public static bool sRoleSceneLoaded = false;

	// Token: 0x04005F0C RID: 24332
	public static GeDemoActor sRoleActor = null;

	// Token: 0x04005F0D RID: 24333
	private static GameObject sEffect = null;

	// Token: 0x04005F0E RID: 24334
	protected static readonly string[] m_ActionTable = new string[]
	{
		"Show_Idle",
		"Show_Idle_special01",
		"Show_Idle_special02"
	};

	// Token: 0x04005F0F RID: 24335
	protected static readonly int[] m_PlayList;

	// Token: 0x04005F10 RID: 24336
	protected static int m_PlayIdx;

	// Token: 0x04005F11 RID: 24337
	private static int jobIDHold;

	// Token: 0x04005F12 RID: 24338
	private static uint[] equipIDsHold;

	// Token: 0x04005F13 RID: 24339
	private static int weaponStrengthenLvHold;

	// Token: 0x04005F14 RID: 24340
	private static string curJobString;

	// Token: 0x04005F15 RID: 24341
	private static bool onSelectRot;

	// Token: 0x04005F16 RID: 24342
	private static float targetAngle;

	// Token: 0x04005F17 RID: 24343
	private static float curAngle;

	// Token: 0x04005F18 RID: 24344
	private static float curAngularSpeed;

	// Token: 0x04005F19 RID: 24345
	private static float curAngularAcc;

	// Token: 0x04005F1A RID: 24346
	private static float curFactor;

	// Token: 0x04005F1B RID: 24347
	private static float curForce;

	// Token: 0x04005F1C RID: 24348
	private static float curTarget;

	// Token: 0x04005F1D RID: 24349
	private static float damp;

	// Token: 0x04005F1E RID: 24350
	private static int lastIdx;

	// Token: 0x04005F1F RID: 24351
	private static bool hasAlign;

	// Token: 0x04005F20 RID: 24352
	private static float curRoleForce;

	// Token: 0x04005F21 RID: 24353
	private static bool canDragRot;

	// Token: 0x04005F22 RID: 24354
	private static readonly string[] m_animTable;

	// Token: 0x04005F23 RID: 24355
	private static readonly string[] m_stateTable;

	// Token: 0x04005F24 RID: 24356
	private static readonly float TIME_SLICE;

	// Token: 0x0200115F RID: 4447
	protected class RoleDemoDesc
	{
		// Token: 0x04005F25 RID: 24357
		public GeDemoActor m_RoleActor;

		// Token: 0x04005F26 RID: 24358
		public GeAttach m_LeftWeapon;

		// Token: 0x04005F27 RID: 24359
		public GeAttach m_RightWeapon;

		// Token: 0x04005F28 RID: 24360
		public string m_JobString;

		// Token: 0x04005F29 RID: 24361
		public GameObject m_CameraNode;

		// Token: 0x04005F2A RID: 24362
		public Transform m_LightRefNode;

		// Token: 0x04005F2B RID: 24363
		public float m_InitHeight;

		// Token: 0x04005F2C RID: 24364
		public int m_PlayIdx;
	}
}
