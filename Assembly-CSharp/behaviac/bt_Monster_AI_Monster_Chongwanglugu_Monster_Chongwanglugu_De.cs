using System;

namespace behaviac
{
	// Token: 0x0200361B RID: 13851
	public static class bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect
	{
		// Token: 0x0601545B RID: 87131 RVA: 0x00669C74 File Offset: 0x00668074
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Chongwanglugu/Monster_Chongwanglugu_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(12);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node13 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node13();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.SetId(13);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node14 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node14();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.SetId(14);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node15 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node15();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.SetId(15);
			sequence.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(16);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node17 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node3 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node17();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node3.SetId(17);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node18 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node4 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node18();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node4.SetId(18);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node4.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node19 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node19();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.SetId(19);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
