using System;

namespace MVP.Presenters
{
    public abstract class Presenter<TView, TModel>
    {
        protected readonly TView _view;
        protected readonly TModel _model;

        protected Presenter(TView view, TModel model)
        {
            _view = view;
            _model = model;

            SetInitialState();
            HookViewEvents();
            HookModelEvents();
        }

        protected virtual void SetInitialState()
        {
        }

        protected virtual void HookViewEvents()
        {
            UnhookViewEvents();
        }

        protected virtual void UnhookViewEvents()
        {
        }

        protected virtual void HookModelEvents()
        {
            UnhookModelEvents();
        }

        protected virtual void UnhookModelEvents()
        {
        }

        protected void ViewAction(Action action)
        {
            UnhookViewEvents();
            action.Invoke();
            HookViewEvents();
        }

        protected void ModelAction(Action action)
        {
            UnhookModelEvents();
            action.Invoke();
            HookModelEvents();
        }
    }
}