using System;

namespace behaviac
{
	// Token: 0x020030FC RID: 12540
	public static class bt_Monster_AI_Chapter10_Fengxiguang_Event
	{
		// Token: 0x06014AA6 RID: 84646 RVA: 0x006391E4 File Offset: 0x006375E4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Fengxiguang_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node3 action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node = new Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node3();
			action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2 action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2 = new Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2();
			action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
