// This file is part of Core WF which is licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace System.Activities.DurableInstancing
{
    using System;
    using System.Activities.Runtime;
    using System.Activities.Runtime.DurableInstancing;
    using System.Activities.Internals;

    [Fx.Tag.XamlVisible(false)]   
    public sealed class QueryActivatableWorkflowsCommand : InstancePersistenceCommand
    {
        public QueryActivatableWorkflowsCommand()
            : base(InstancePersistence.ActivitiesCommandNamespace.GetName("QueryActivatableWorkflows"))
        {
        }

        protected internal override bool IsTransactionEnlistmentOptional
        {
            get
            {
                return true;
            }
        }

        protected internal override void Validate(InstanceView view)
        {
            if (!view.IsBoundToInstanceOwner)
            {
                throw FxTrace.Exception.AsError(new InvalidOperationException(SR.OwnerRequired));
            }

            if (view.IsBoundToInstance)
            {
                throw FxTrace.Exception.AsError(new InvalidOperationException(SR.AlreadyBoundToInstance));
            }
        }
    }
}
