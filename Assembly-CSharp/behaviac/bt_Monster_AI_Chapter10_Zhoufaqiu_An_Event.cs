using System;

namespace behaviac
{
	// Token: 0x02003166 RID: 12646
	public static class bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event
	{
		// Token: 0x06014B67 RID: 84839 RVA: 0x0063CE00 File Offset: 0x0063B200
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Zhoufaqiu_An_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3 parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node = new Parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3();
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetId(3);
			bt.AddChild(parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.AddChild(sequence);
			Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node7 action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node = new Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node7();
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2 action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2 = new Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2();
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.AddChild(sequence2);
			Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node8 action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3 = new Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node8();
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3.HasEvents());
			Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node6 action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node4 = new Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node6();
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node4.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node4.HasEvents());
			parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.SetHasEvents(parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node.HasEvents());
			return true;
		}
	}
}
