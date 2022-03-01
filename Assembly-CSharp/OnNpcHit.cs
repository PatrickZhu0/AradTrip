using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020045EE RID: 17902
public class OnNpcHit : MonoBehaviour
{
	// Token: 0x060192C7 RID: 103111 RVA: 0x007F5C44 File Offset: 0x007F4044
	private void Update()
	{
		if (!GameFrameWork.IsGameFrameWorkInited)
		{
			return;
		}
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown) && !(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
		{
			return;
		}
		bool flag = false;
		if (Input.GetMouseButtonDown(0))
		{
			if (null != EventSystem.current && EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			flag = true;
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == null)
		{
			if (null != EventSystem.current && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			{
				return;
			}
			flag = true;
		}
		if (flag)
		{
			Camera main = Camera.main;
			if (null != main)
			{
				Ray ray = main.ScreenPointToRay(Input.mousePosition);
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, ref raycastHit, float.PositiveInfinity) && null != raycastHit.collider)
				{
					Transform transform = raycastHit.collider.transform;
					if (transform != null)
					{
						RaycastObject component = transform.GetComponent<RaycastObject>();
						if (component != null)
						{
							if (component.ObjectType == RaycastObject.RaycastObjectType.ROT_NPC)
							{
								TaskNpcAccess.OnClickNpc(component.Data as BeTownNPCData);
							}
							else if (component.ObjectType == RaycastObject.RaycastObjectType.ROT_TOWNPLAYER)
							{
								ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
								if (clientSystemGameBattle != null)
								{
									CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
									if (tableItem != null)
									{
										TaskNpcAccess.OnClickFightPlayer(component.Data as BeFighterData, tableItem.SceneType, raycastHit.transform);
									}
								}
								else
								{
									TaskNpcAccess.OnClickTownPlayer(component.Data as BeTownPlayerData, raycastHit.transform);
								}
							}
						}
					}
				}
			}
		}
	}
}
