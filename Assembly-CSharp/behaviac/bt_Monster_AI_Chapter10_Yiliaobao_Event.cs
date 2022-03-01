using System;

namespace behaviac
{
	// Token: 0x02003152 RID: 12626
	public static class bt_Monster_AI_Chapter10_Yiliaobao_Event
	{
		// Token: 0x06014B45 RID: 84805 RVA: 0x0063C410 File Offset: 0x0063A810
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Yiliaobao_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(6);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node0 action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node = new Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node0();
			action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node8 action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node2 = new Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node8();
			action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node2.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
