using System;

namespace behaviac
{
	// Token: 0x02003576 RID: 13686
	public static class bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event
	{
		// Token: 0x06015321 RID: 86817 RVA: 0x00663634 File Offset: 0x00661A34
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Huodong/Ani3thMG_Zhoufaqiu_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node3 action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node = new Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node3();
			action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node.HasEvents());
			Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2 action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2 = new Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2();
			action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
