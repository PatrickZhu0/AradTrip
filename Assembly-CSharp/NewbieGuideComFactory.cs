using System;
using GameClient;
using UnityEngine;

// Token: 0x02001058 RID: 4184
[LoggerModel("NewbieGuide")]
public class NewbieGuideComFactory
{
	// Token: 0x06009D2A RID: 40234 RVA: 0x001EE8C0 File Offset: 0x001ECCC0
	public static ComNewbieGuideBase _addComponent<T>(GameObject go, params object[] args) where T : ComNewbieGuideBase
	{
		T t = go.AddComponent<T>();
		if (t != null)
		{
			t.StartInit(args);
		}
		else
		{
			Logger.LogError("comp is nil");
		}
		return t;
	}

	// Token: 0x06009D2B RID: 40235 RVA: 0x001EE908 File Offset: 0x001ECD08
	public static ComNewbieGuideBase _addComponent(GameObject go, Type type, params object[] args)
	{
		if (go == null)
		{
			Logger.LogError("NewbieGuideComFactory go is null!");
		}
		if (type == null)
		{
			Logger.LogError("NewbieGuideComFactory Type must Drive From ComNewbieGuideBase!");
		}
		ComNewbieGuideBase comNewbieGuideBase = go.AddComponent(type) as ComNewbieGuideBase;
		if (comNewbieGuideBase != null)
		{
			comNewbieGuideBase.StartInit(args);
		}
		else
		{
			Logger.LogError("comp is nil");
		}
		return comNewbieGuideBase;
	}

	// Token: 0x06009D2C RID: 40236 RVA: 0x001EE96C File Offset: 0x001ECD6C
	public static ComNewbieGuideBase AddNewbieCom(GameObject go, ComNewbieData data)
	{
		if (go == null)
		{
			return null;
		}
		NewbieGuideComType comType = data.ComType;
		switch (comType + 1)
		{
		case NewbieGuideComType.BUTTON:
			return NewbieGuideComFactory._addComponent(go, data.ComNewbieGuideType, data.args);
		case NewbieGuideComType.ETC_BUTTON:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideButton>(go, data.args);
		case NewbieGuideComType.ETC_JOYSTICK:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideETCButton>(go, data.args);
		case NewbieGuideComType.MOVE_2_POS:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideETCJoystick>(go, data.args);
		case NewbieGuideComType.PAUSE_BATTLE:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideMove2Position>(go, data.args);
		case NewbieGuideComType.RESUME_BATTLE:
			return NewbieGuideComFactory._addComponent<ComNewbieGuidePauseBattle>(go, data.args);
		case NewbieGuideComType.SYSTEM_BUTTON:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideResumeBattle>(go, data.args);
		case NewbieGuideComType.TALK_DIALOG:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideSystemButton>(go, data.args);
		case NewbieGuideComType.TOGGLE:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideTalkDialog>(go, data.args);
		case NewbieGuideComType.WAIT:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideToggle>(go, data.args);
		case NewbieGuideComType.INTRODUCTION:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideWait>(go, data.args);
		case NewbieGuideComType.INTRODUCTION2:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideIntroduction>(go, data.args);
		case NewbieGuideComType.COVER:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideIntroduction2>(go, data.args);
		case NewbieGuideComType.PASS_THROUGH:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideCover>(go, data.args);
		case NewbieGuideComType.SHOW_IMAGE:
			return NewbieGuideComFactory._addComponent<ComNewbieGuidePassThrough>(go, data.args);
		case NewbieGuideComType.STRESS:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideShowImage>(go, data.args);
		case NewbieGuideComType.OPEN_EYES:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideStress>(go, data.args);
		case NewbieGuideComType.NEWICON_UNLOCK:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideOpenEyes>(go, data.args);
		case NewbieGuideComType.BATTLEDRUGDRAG:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideNewIconUnlock>(go, data.args);
		case NewbieGuideComType.PLAY_EFFECT:
			return NewbieGuideComFactory._addComponent<ComNewbieGuideBattleDrugDrag>(go, data.args);
		case (NewbieGuideComType)20:
			return NewbieGuideComFactory._addComponent<ComNewbieGuidePlayEffect>(go, data.args);
		default:
			return null;
		}
	}
}
