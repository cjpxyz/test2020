﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ns
{
    ///<summary>
    ///
    ///</summary>
    public class enemy : MonoBehaviour
    {
        public int Speed = 10;
        Transform[] wayTrans;
        int index = 0;
        Rigidbody rid;
        private void Awake()
        {
            wayTrans = wayPoint.tans;
            rid = this.transform.GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (index>= wayTrans.Length-1)
            {
                return;
            }
            this.transform.LookAt(wayTrans[index + 1]);
            this.transform.position += this.transform.forward * Speed * Time.deltaTime;
            
            if (Vector3.Distance(this.transform.position, wayTrans[index+1].position)<0.2f)
            {
                index++;
            }
            if (index>= wayTrans.Length-1)
            {
                finishEnd();
            }
            
        }
        void finishEnd()
        {
            
            GameObject.Destroy(this.gameObject);
        }
        void OnDestroy()
        {
            enemySpawner.aliveEnemyCount--;
            
        }

        public void takeDemage(float demage)
        {

        }
    }

}

