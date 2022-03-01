using System;

namespace behaviac
{
	// Token: 0x02003567 RID: 13671
	public static class bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event
	{
		// Token: 0x06015308 RID: 86792 RVA: 0x00662E98 File Offset: 0x00661298
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Huodong/Ani3thMG_Jinbi_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node3 condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node = new Condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node3();
			condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.HasEvents());
			Action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node2 action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node = new Action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node2();
			action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
