//
//  main.c
//  lib
//
//  Created by Слава on 09.12.2021.
//

#include <stdio.h>
#include <stdlib.h>

#define array_size 25

    void __stdcall input_array(int* array)
    {
        for (int i = 0; i < array_size; i++)
        {
            array[i] = rand() % 200 - 99;
        }
    };
    void __stdcall output_array(int* array)
    {
        for (int i = 0; i < array_size; i++)
        {
            printf("%d: %d\n", i, array[i]);
        }
    };
    int __stdcall processing_array(int* array)
    {
        double sum = 0;
        double result = 0;
        for (int i = 0; i < array_size; i++)
        {
            if (i % 2 != 0)
                sum += array[i];
        }
        result = sum * sum;
        return result;
    };
