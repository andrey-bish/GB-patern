using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Asteroids.Interface;


namespace Asteroids.Models
{
    public class TimeRewinder: IUpdateble, IFixUpdateble
    {
        private readonly Dictionary<Rigidbody2D, List<PointTime>> _points = new Dictionary<Rigidbody2D, List<PointTime>>();
        private bool _isRewinding = false;
        private float _recordTime;

        public TimeRewinder(float recordTime)
        {
            _recordTime = recordTime;
        }

        public void AddRewinder(Rigidbody2D rigidbody)
        {
            if (_points.FirstOrDefault(x => x.Key == rigidbody).Key == null)
            {
                _points.Add(rigidbody, new List<PointTime>());
            }
            return;
        }

        public void RemoveRewinder(Rigidbody2D rigidbody)
        {
            var removing = _points.FirstOrDefault(x => x.Key == rigidbody).Key;
            if (removing != null)
            {
                _points.Remove(removing);
            }
        }

        private void Rewind()
        {
            foreach (var item in _points)
            {
                if (_points.Count > 1)
                {
                    PointTime pointInTime = item.Value[0];
                    item.Key.transform.position = pointInTime.Position;
                    item.Key.transform.rotation = pointInTime.Rotation;
                    item.Value.RemoveAt(0);
                }
                else
                {
                    PointTime pointInTime = item.Value[0];
                    item.Key.transform.position = pointInTime.Position;
                    item.Key.transform.rotation = pointInTime.Rotation;
                    StopRewind();
                }
            }
        }
        private void Record()
        {
            foreach (var item in _points)
            {
                if (_points.Count > Mathf.Round(_recordTime /
                                                Time.fixedDeltaTime))
                {
                    item.Value.RemoveAt(item.Value.Count - 1);
                }
                item.Value.Insert(0, new PointTime(item.Key.transform.position,
                    item.Key.transform.rotation, item.Key.velocity, item.Key.angularVelocity));
            }

        }

        private void StartRewind()
        {
            foreach (var item in _points)
            {
                _isRewinding = true;
                item.Key.isKinematic = true;
            }
        }
        private void StopRewind()
        {
            foreach (var item in _points)
            {
                _isRewinding = false;
                item.Key.isKinematic = false;
                item.Key.velocity = item.Value[0].Velocity;
                item.Key.angularVelocity = item.Value[0].AngularVelocity;
            }

        }

        public void Updateble(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.B))
            {
                StopRewind();
            }
        }

        public void FixUpdateble(float deltaTime)
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }
    }
}
